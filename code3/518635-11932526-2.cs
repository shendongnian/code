    var bytes = (byte[])value;
    var image = new BitmapImage();
    image.BeginInit();
    if (bytes == null) 
    {
        // Processing null case
    }
    else
    {
        using (var ms = new MemoryStream(bytes))
        {
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = ms;
            image.EndInit();
        }
    }
    return image;
