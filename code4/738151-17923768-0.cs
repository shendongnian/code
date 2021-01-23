    private static BitmapImage GetBitmapImage(string imageFilePath)
    {
        BitmapImage bmpImage = new BitmapImage();
        bmpImage.BeginInit();
        Uri uri = new Uri(imageFilePath);
        bmpImage.UriSource = uri;
        bmpImage.CacheOption = BitmapCacheOption.OnLoad;
        bmpImage.EndInit();
        return bmpImage;
    }
