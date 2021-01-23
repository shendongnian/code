    FilterInfoCollection videoDevices = 
        new FilterInfoCollection(FilterCategory.VideoInputDevice);
    VideoCaptureDevice videoDevice = 
        new VideoCaptureDevice(videoDevices[camDevice].MonikerString);
    
    videoDevice.SetCameraProperty(
        CameraControlProperty.Zoom,
        zoomValue,
        CameraControlFlags.Manual);
    videoDevice.SetCameraProperty(
        CameraControlProperty.Focus,
        focusValue,
        CameraControlFlags.Manual);
    videoDevice.SetCameraProperty(
        CameraControlProperty.Exposure,
        exposureValue,
        CameraControlFlags.Manual);
