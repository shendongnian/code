    void Update () {
        if(Input.GetMouseButtonDown(0)){
            // get ray from camera in to scene at the mouse position
            Ray ray = Camera.mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
        
            // hardcoded "zoom" distance.
            float zoomDist = 15.0f;
			
            // Raycast from camera to mouse cursor, if object hit, zoom.
            if (Physics.Raycast(ray,out hit,Mathf.Infinity)){		
                // Create a second ray from the hit object back out, zoom the camera along this ray.
                Ray r = new Ray(hit.point,hit.normal);
                Camera.mainCamera.transform.position = r.GetPoint(zoomDist);
            }
        }
    }
