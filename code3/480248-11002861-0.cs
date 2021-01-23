    // Decode image format
    var decoder = await BitmapDecoder.CreateAsync(fileStream);
    var transform = new BitmapTransform();
    var pixelData = await decoder.GetPixelDataAsync(decoder.BitmapPixelFormat, decoder.BitmapAlphaMode, transform, ExifOrientationMode.RespectExifOrientation, ColorManagementMode.ColorManageToSRgb);
    
    // Swap R and B channels since it's reversed
    var pixels = pixelData.DetachPixelData();
    for (var i = 0; i < pixels.Length; i += 4)
    {
    	var r = pixels[i];
    	var b = pixels[i + 2];
    	pixels[i] = b;
    	pixels[i + 2] = r;
    }
    
    // Copy pixels to WriteableBitmap
    var wb = new WriteableBitmap((int)decoder.PixelWidth, (int)decoder.PixelHeight);
    using (var bmpStream = wb.PixelBuffer.AsStream())
    {
    	bmpStream.Seek(0, SeekOrigin.Begin);
    	bmpStream.Write(pixels, 0, (int)bmpStream.Length);
    }
    
    
    // Your original code
    var newWB = wb.Flip(FlipMode.Vertical);
    ImageControl.Source = newWB; 
