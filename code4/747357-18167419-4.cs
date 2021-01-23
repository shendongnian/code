    public static BitmapImage LoadBitmapImage(string fileName)
    {
        using (var stream = new FileStream(fileName, FileMode.Open))
        {
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.StreamSource = stream;
            bitmapImage.EndInit();
            bitmapImage.Freeze(); 
            return bitmapImage;
        }
    }
