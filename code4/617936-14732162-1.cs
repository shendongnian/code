    while (_ProcessThreadRunning)
    {
       readWriteThread.WaitOne();
       imageBoxTrhead.Reset();
       
       //  _Camera.LiveFrame is the Bitmap
       procImage = new Image<Bgr, int>((Bitmap)_Camera.LiveFrame.Clone());          
       procImage.Draw(new Rectangle(10,20,20,15),new Bgr(Color.LightGreen), 5);
       
       imageBoxTrhead.Set();
       
       ibProcessed.Image = procImage;
       ibProcessed.Invalidate();
    }
    _ProcessExitEvent.Set();
