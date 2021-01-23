    var renderTargetBitmap = getRenderTargetBitmap();
    var bitmapImage = new BitmapImage();
    var bitmapEncoder = new PngBitmapEncoder();
    bitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
    using (var stream = new MemoryStream())
    {
        bitmapEncoder.Save(stream);
        stream.Seek(0, SeekOrigin.Begin);
        bitmapImage.BeginInit();
        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        bitmapImage.StreamSource = stream;
        bitmapImage.EndInit();
    }
