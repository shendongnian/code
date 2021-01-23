    public static BitmapSource ToBitmapImage(this byte[] bytes)
    {
        using (var stream = new MemoryStream(bytes))
        {
            var decoder = BitmapDecoder.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            return decoder.Frames[0];
        }
    }
