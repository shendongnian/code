    public void Resize()
    {
        double scaleFactor = 33.5;
    
        var originalFileStream = System.IO.File.OpenRead(@"D:\SkyDrive\Pictures\Random\Misc\DoIt.jpg");
    
        var originalBitmapDecoder = JpegBitmapDecoder.Create(originalFileStream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
    
        BitmapFrame originalBitmapFrame = originalBitmapDecoder.Frames.First();
    
        var originalPixelFormat = originalBitmapFrame.Format;
    
        TransformedBitmap transformedBitmap =
            new TransformedBitmap(originalBitmapFrame, new System.Windows.Media.ScaleTransform()
            {
                ScaleX = scaleFactor,
                ScaleY = scaleFactor
            });
    
        int stride = ((transformedBitmap.PixelWidth * transformedBitmap.Format.BitsPerPixel) + 7) / 8;
        int pixelCount = (stride * (transformedBitmap.PixelHeight - 1)) + stride;
    
        byte[] buffer = new byte[pixelCount];
    
        transformedBitmap.CopyPixels(buffer, stride, 0);
    
        WriteableBitmap transformedWriteableBitmap = new WriteableBitmap(transformedBitmap.PixelWidth, transformedBitmap.PixelHeight, transformedBitmap.DpiX, transformedBitmap.DpiY, transformedBitmap.Format, transformedBitmap.Palette);
    
        transformedWriteableBitmap.WritePixels(new Int32Rect(0, 0, transformedBitmap.PixelWidth, transformedBitmap.PixelHeight), buffer, stride, 0);
    
        BitmapFrame transformedFrame = BitmapFrame.Create(transformedWriteableBitmap);
    
        var jpegEncoder = new JpegBitmapEncoder();
        jpegEncoder.Frames.Add(transformedFrame);
    
        using (var outputFileStream = System.IO.File.OpenWrite(@"C:\DATA\Scrap\WPF.jpg"))
        {
            jpegEncoder.Save(outputFileStream);
        }
    }
