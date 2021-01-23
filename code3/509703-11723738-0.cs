    private WriteableBitmap wBitmap; 
    private byte[] pixels;
    private void WindowLoaded(...)
    {
        //set up kinect first, but don't start it
        ...
       
        pixels = new byte[sensor.ColorStream.FramePixelDataLength];
    
        wBitmap = new WriteableBitmap(sensor.ColorStream.FrameWidth, sensor.ColorStream.FrameHeight, 
            96, 96, PixelFormats.Bgra32, null);
    
        video.Source = wBitmap;
        sensor.Start();
    }
    private void ColorFrameReady(object sender, ColorImageFrameReadyArgs e)
    {
        using (ColorImageFrame colorFrame = e.OpenColorImageFrame())
        {
            if (colorFrame == null)
            {
                return;
            }
            colorFrame.CopyPixelDataTo(pixels);
            wBitmap.WritePixels(new Int32Rect(0, 0, wBitmap.PixelWidth, wBitmap.PixelHeight),
                pixels, image.PixelWidth * 4, 0);
        }
    }
