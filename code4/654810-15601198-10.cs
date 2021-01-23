    public static ImageSource LoadImage(string fileName)
    {
        var image = new BitmapImage();
        using (var stream = new FileStream(fileName, FileMode.Open))
        {
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = stream;
            image.EndInit();
        }
        return image;
    }
