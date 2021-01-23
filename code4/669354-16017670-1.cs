    if (_camerContext != null)
    {
      _cameraContext.NewFrame -= Handle_New_Frame;
    }
    _cameraContext = new VideoCaptureDevice(blah blah blah);
    _cameraContext.NewFrame += Handle_New_Frame;
    videoSourcePlayer1.Visible = false;
    _cameraContext.Start();
