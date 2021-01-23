    using (var sourceStream = await sourceFile.OpenAsync(FileAccessMode.Read))
    {
        BitmapDecoder decoder = await BitmapDecoder.CreateAsync(sourceStream);
        BitmapTransform transform = new BitmapTransform() { ScaledHeight = 80, ScaledWidth = 80 };
        PixelDataProvider pixelData = await decoder.GetPixelDataAsync(
            BitmapPixelFormat.Rgba8,
            BitmapAlphaMode.Straight,
            transform,
            ExifOrientationMode.RespectExifOrientation,
            ColorManagementMode.DoNotColorManage);
    
        using (var destinationStream = await destinationFile.OpenAsync(FileAccessMode.ReadWrite))
        {
            BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, destinationStream);
            encoder.SetPixelData(BitmapPixelFormat.Rgba8, BitmapAlphaMode.Premultiplied, 80, 80, 96, 96, pixelData.DetachPixelData());                        
            await encoder.FlushAsync();
        }
    }
