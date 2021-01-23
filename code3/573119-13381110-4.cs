    void sensor_DepthFrameReady(object sender
        , DepthImageFrameReadyEventArgs e)
    {
        using (var depthFrame = e.OpenDepthImageFrame())
        {
            if (depthFrame != null)
            {
                var bits =
                    new short[depthFrame.PixelDataLength];
                depthFrame.CopyPixelDataTo(bits);
                // your code goes here
            }
        }
    }
     
