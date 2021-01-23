    while (_CaptureThreadRunning)
    {
       imageBoxTrhead.WaitOne();
       readWriteThread.Reset();
        
       // _Camera.GetFrame writes to the Bitmap
       if (_VideoPlaying && _Camera.GetFrame(500)) 
          pbLiveFeed.Invalidate();
       readWriteThread.Set();
       
    }
    _Camera.CloseCamera(true);
    _CaptureExitEvent.Set();
