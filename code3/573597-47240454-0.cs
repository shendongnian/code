        BitmapData data = bitMap.LockBits( 
    			             new System.Drawing.Rectangle(0,0,bitMap.Width,bitMap.Height), 
    			             System.Drawing.Imaging.ImageLockMode.ReadOnly, 
    			             bitMap.PixelFormat);
        BitmapSource source = BitmapSource.Create(bitMap.Width, bitMap.Height, 
			                         bitMap.HorizontalResolution, bitMap.VerticalResolution, 
			                         System.Windows.Media.PixelFormats.Rgb24, null,
			                         data.Scan0, data.Stride * bitMap.Height, data.Stride);
        bitMap.UnlockBits(data);
        var jpegBitmapEncoder = new JpegBitmapEncoder();
        jpegBitmapEncoder.QualityLevel = jpgQuality;
        jpegBitmapEncoder.Frames.Add(BitmapFrame.Create(source));
        var jpegStream = new MemoryStream();
        jpegBitmapEncoder.Save(jpegStream);
