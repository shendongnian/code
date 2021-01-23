    public BitmapImage GetBitmapImage(byte[] imageData)
    {
        BitmapImage bitmapImage = new BitmapImage();
        
        using (MemoryStream imageStream = new MemoryStream(imageData))
        using (Image image = Image.FromStream(imageStream))
        using (MemoryStream convertedImageStream = new MemoryStream())
        {
            bitmapImage.BeginInit();
            
            image.Save(convertedImageStream, ImageFormat.Png);
            
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.StreamSouce = convertedImageStream;
            
            bitMapImage.EndInit();
        }
        
        return bitmapImage;
    }
