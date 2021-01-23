    using UnityEngine;
    using System.Collections;
    
    public class CameraZoom : MonoBehaviour
    {
        public int zoomLevelSelected = 0;
        public float[] ZoomLevels = new float[] { 60, 40, 20 };
        int zoomChange = 0;  //<<<<<<<<<<<<<
    
        void Update()
        {
            if (Input.GetMouseButtonDown(0)) { zoomChange = +1; } // back
            else if (Input.GetMouseButtonDown(1)) { zoomChange = -1; } // forward
            if (zoomChange != 0)
            {
                zoomLevelSelected = Mathf.Clamp(zoomLevelSelected + zoomChange, 0, ZoomLevels.Length - 1);
                camera.fieldOfView = ZoomLevels[zoomLevelSelected];
            }
        }
    }
