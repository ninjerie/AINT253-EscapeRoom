﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float minY = -30f;
    public float maxY = 30f;

    public float mouseSensitivity = 100f;
    private Vector2 mouseDirection;
    private Transform body;
    
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.None;
        
        //Cursor.visible = true;

        body = this.transform.parent.transform;
    }

    void Update()
    {
        Vector2 mouseChange = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseDirection += mouseChange;
        mouseDirection.y = Mathf.Clamp(mouseDirection.y, minY, maxY);

        this.transform.localRotation = Quaternion.AngleAxis(-mouseDirection.y, Vector3.right);
        body.localRotation = Quaternion.AngleAxis(mouseDirection.x, Vector3.up);
    }
}
