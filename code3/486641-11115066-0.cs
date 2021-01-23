        private static readonly int Bgr32BytesPerPixel = (PixelFormats.Bgr32.BitsPerPixel + 7) / 8;
        private byte[] pixelData;
        private WriteableBitmap CameraSource;
    
    private void ColorImageReady(object sender, ColorImageFrameReadyEventArgs e)
            {
               bool receivedData = false;
                using (ColorImageFrame imageFrame = e.OpenColorImageFrame())
                {
                    if (imageFrame != null)
                    {
    
                        if (pixelData == null)
                        {
                            this.pixelData = new byte[imageFrame.PixelDataLength];
                        }
    
                        imageFrame.CopyPixelDataTo(this.pixelData);
                        receivedData = true;
    
                        // A WriteableBitmap is a WPF construct that enables resetting the Bits of the image.
                        // This is more efficient than creating a new Bitmap every frame.
                        if (receivedData)
                        {
                       
    
                        this.CameraSource.WritePixels(
                            new Int32Rect(0, 0, imageFrame.Width, imageFrame.Height),
                            this.pixelData,
                            imageFrame.Width * Bgr32BytesPerPixel,
                            0);
                        }
    
                    }
                }
            }
