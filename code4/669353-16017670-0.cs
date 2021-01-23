    cam = new 
      VideoCaptureDevice(captureDevices[CameraSelectComboBox.SelectedIndex].MonikerString);
    cam.NewFrame -= Handle_New_Frame; // you're pointing to the new instance of VCD, so this will have no effect.
    cam.NewFrame += new AForge.Video.NewFrameEventHandler(Handle_New_Frame);
    videoSourcePlayer1.Visible = false;
    cam.Start();
