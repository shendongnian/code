    protected override void OnNavigatingFrom(System.Windows.Navigation.NavigatingCancelEventArgs e)
    {
        if (cam != null)
        {
            // Dispose camera to minimize power consumption and to expedite shutdown. 
            cam.Dispose();
    
            // Release memory, ensure garbage collection. 
            cam.Initialized -= cam_Initialized;
            cam.CaptureCompleted -= cam_CaptureCompleted;
            cam.CaptureImageAvailable -= cam_CaptureImageAvailable;
            cam.CaptureThumbnailAvailable -= cam_CaptureThumbnailAvailable;
            cam.AutoFocusCompleted -= cam_AutoFocusCompleted;
            CameraButtons.ShutterKeyHalfPressed -= OnButtonHalfPress;
            CameraButtons.ShutterKeyPressed -= OnButtonFullPress;
            CameraButtons.ShutterKeyReleased -= OnButtonRelease;
        }
    } 
