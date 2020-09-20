﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ogroupblockscript : MonoBehaviour {

    public static int drop = -1;
    private float time = 0;
    private float span = 1;
    public static int canmove = 0;

    // Use this for initialization
    void Start () {
        drop = -1;
        time = 0;
        span = 1;
        canmove = 0;
    }

    // Update is called once per frame
    void Update () {
        this.time += Time.deltaTime;
        if (canmove == 0) {
            if (this.time > span) {
                time = 0;
                transform.Translate(0, drop, 0, Space.World);
                if (drop == 0) {
                    canmove = 1;
                    Deletescript.finish = 1;
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow)) {
                if (drop == -1) {
                    span = 0.2f;
                }
                if (drop == 0) {
                    span = 1.1f;
                }
            }
            if (Input.GetKeyUp(KeyCode.DownArrow)) {
                if (drop == -1) {
                    span = 1;
                }
                if (drop == 0) {
                    span = 1.1f;
                }
            }
            if (Input.GetKeyDown(KeyCode.Z)) {
                transform.Rotate(0, 0, 90);
                if (Ooneblockscript.flag == false) {
                    Ooneblockscript.flag = true;
                } else if (Ooneblockscript.flag == true) {
                    Ooneblockscript.flag = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.X)) {
                transform.Rotate(0, 0, -90);
                if (Ooneblockscript.flag == false) {
                    Ooneblockscript.flag = true;
                } else if (Ooneblockscript.flag == true) {
                    Ooneblockscript.flag = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                transform.position += new Vector3(1, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                transform.position += new Vector3(-1, 0, 0);
            }
        }
        if (Ooneblockscript.delete == 1) {
            Destroy(this.gameObject);
            blockcreater.create = 1;
            Ooneblockscript.delete = 0;
        }
    }
    private void OnCollisionStay(Collision col) {
        if (LayerMask.LayerToName(col.gameObject.layer) == "leftwall") {
            transform.position += new Vector3(1, 0, 0);
        }
        if (LayerMask.LayerToName(col.gameObject.layer) == "rightwall") {
            transform.position += new Vector3(-1, 0, 0);
        }
        if (LayerMask.LayerToName(col.gameObject.layer) == "othercol") {
            if (canmove == 0) {
                transform.position += new Vector3(0, 1, 0);
            }
        }
    }
    private void OnCollisionEnter(Collision col) {
        if (LayerMask.LayerToName(col.gameObject.layer) == "downwall") {
            drop = 0;
        }
        if (LayerMask.LayerToName(col.gameObject.layer) == "otherblock") {
            drop = 0;
        }
    }
    private void OnCollisionExit(Collision col) {
        if (LayerMask.LayerToName(col.gameObject.layer) == "otherblock") {
            drop = -1;
        }
    }
}
