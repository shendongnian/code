    string filename = ...
    BitmapImage image = new BitmapImage();
    using (var stream =
        new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
    {
        image.BeginInit();
        image.CacheOption = BitmapCacheOption.OnLoad;
        image.StreamSource = stream;
        image.EndInit();
    }
