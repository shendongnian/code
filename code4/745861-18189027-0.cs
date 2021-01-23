     DsDevice[] devs = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice); // getting video devices
     IFilterGraph2 graphBuilder = new FilterGraph() as IFilterGraph2; 
     IBaseFilter capFilter = null;
     if (graphBuilder != null)
     graphBuilder.AddSourceFilterForMoniker(devs[0].Mon, null, devs[0].Name, 
        out capFilter); //getting capture filter for converting it into IAMCameraControl
     IAMCameraControl _camera = capFilter as IAMCameraControl;
     _camera.Set(CameraControlProperty.Focus, 250, CameraControlFlags.Manual); //Setting focus to macro (in my camera, range between 0 - 250)
