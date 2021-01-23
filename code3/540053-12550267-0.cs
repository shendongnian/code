    private async Task<byte[]> GetDataAsync(IRandomAccessStream stream)
    {
        BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream).AsTask().ConfigureAwait(false);
    
        BitmapFrame frame = await decoder.GetFrameAsync(0).AsTask().ConfigureAwait(false);
    
        BitmapTransform transform = new BitmapTransform()
        {
            ScaledWidth = decoder.PixelWidth,
            ScaledHeight = decoder.PixelHeight
        };
    
        PixelDataProvider pixelData = await frame.GetPixelDataAsync(BitmapPixelFormat.Rgba8, BitmapAlphaMode.Straight, transform, ExifOrientationMode.IgnoreExifOrientation, ColorManagementMode.DoNotColorManage).AsTask().ConfigureAwait(false);
    
        return pixelData.DetachPixelData();
    }
