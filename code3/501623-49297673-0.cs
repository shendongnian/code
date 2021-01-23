    private Vector3 MouseDownPosition;
    void Update()
    {
        // If mouse wheel scrolled vertically, apply zoom...
        // TODO: Add pinch to zoom support (touch input)
        if (Input.mouseScrollDelta.y != 0)
        {
            // Save location of mouse prior to zoom
            var preZoomPosition = getWorldPoint(Input.mousePosition);
            // Apply zoom (might want to multiply Input.mouseScrollDelta.y by some speed factor if you want faster/slower zooming
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize + Input.mouseScrollDelta.y, 5, 80);
            // How much did mouse move when we zoomed?
            var delta = getWorldPoint(Input.mousePosition) - preZoomPosition;
            // Rotate camera to top-down (right angle = 90) before applying adjustment (otherwise we get "slide" in direction of camera angle).
            // TODO: If we allow camera to rotate on other axis we probably need to adjust that also.  At any rate, you want camera pointing "straight down" for this part to work.
            var rot = Camera.main.transform.localEulerAngles;
            Camera.main.transform.localEulerAngles = new Vector3(90, rot.y, rot.z);
            // Move the camera by the amount mouse moved, so that mouse is back in same position now.
            Camera.main.transform.Translate(delta.x, delta.z, 0);
            // Restore camera rotation
            Camera.main.transform.localEulerAngles = rot;
        }
        // When mouse is first pressed, just save location of mouse/finger.
        if (Input.GetMouseButtonDown(0))
        {
            MouseDownPosition = getWorldPoint(Input.mousePosition);
        }
        // While mouse button/finger is down...
        if (Input.GetMouseButton(0))
        {
            // Total distance finger/mouse has moved while button is down
            var delta = getWorldPoint(Input.mousePosition) - MouseDownPosition;
            // Adjust camera by distance moved, so mouse/finger stays at exact location (in world, since we are using getWorldPoint for everything).
            Camera.main.transform.Translate(delta.x, delta.z, 0);
        }
    }
    // This works by casting a ray.  For this to work well, this ray should always hit your "ground".  Setup ignore layers if you need to ignore other colliders.
    // Only tested this with a simple box collider as ground (just one flat ground).
    private Vector3 getWorldPoint(Vector2 screenPoint)
    {
        RaycastHit hit;
        Physics.Raycast(Camera.main.ScreenPointToRay(screenPoint), out hit);
        return hit.point;
    }
}
