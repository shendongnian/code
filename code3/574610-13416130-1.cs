    var bytes = await new WebClient().DownloadDataTaskAsync(url);
    var image = new BitmapImage();
    image.BeginInit();
    image.CacheOption = BitmapCacheOption.OnLoad;
    image.StreamSource = new MemoryStream(bytes);
    image.EndInit();
    RSSImage.Source = image;
