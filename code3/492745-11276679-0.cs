    string path = "SplashDemo.Resources.Untitled-100000.png";
    using (Stream fileStream = GetType().Assembly.GetManifestResourceStream(path))
    {
        PngBitmapDecoder bitmapDecoder = new PngBitmapDecoder(fileStream,
            BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
        ImageSource imageSource = bitmapDecoder.Frames[0];
        image.Source = imageSource;
    }
