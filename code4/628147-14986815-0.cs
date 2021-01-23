    private KinectSensor sensor;
    private byte[] colorPixels;
    private Image<Gray, UInt16> grayImage;
    // during init:
    this.colorPixels = new byte[this.sensor.ColorStream.FramePixelDataLength];
    grayImage = new Emgu.CV.Image<Gray, UInt16>(this.sensor.ColorStream.FrameWidth, this.sensor.ColorStream.FrameHeight, new Gray(0));
    
    // the callback for the Kinect SDK
    private void SensorColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
    {
        using (ColorImageFrame colorFrame = e.OpenColorImageFrame())
        {
            if (colorFrame != null)
            {
                // Copy the pixel data from the image to a temporary array
                colorFrame.CopyPixelDataTo(this.colorPixels);
    
                int width = 640;
                int height = 480;
                int bytesPerPx = 2;
                if (nthShot == 0)
                {
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            grayImage[height - y -1, x] = new Gray(((this.colorPixels[(y * width + x) * bytesPerPx + 1])));
                        }
                    }
                    // *** processing of the image comes here ***
                }
                nthShot++;
                if (nthShot == 4)
                    nthShot = 0;
            }
        }
    }
