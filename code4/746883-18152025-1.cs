    BitmapImage img = new BitmapImage();
    using (var webResponse = webRequest.GetResponse())
    using (var responseStream = webResponse.GetResponseStream())
    using (var memoryStream = new MemoryStream())
    {
        responseStream.CopyTo(memoryStream);
        img.BeginInit();
        img.CacheOption = BitmapCacheOption.OnLoad;
        img.StreamSource = memoryStream;
        img.EndInit();
    }
    return img;
