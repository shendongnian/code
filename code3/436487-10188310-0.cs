    void sensor_AllFramesReady(object sender, AllFramesReadyEventArgs e)  
    {
        var frameReadyThread = new Thread(() =>
        using (DepthImageFrame depthFrame = e.OpenDepthImageFrame()) 
        {
            //
        }
        frameReadyThread.Start();
    }
