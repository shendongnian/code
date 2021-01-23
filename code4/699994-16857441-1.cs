    Image image = new Image();
    using (MemoryStream stream = new MemoryStream(byteArray))
    {
        image.Source = BitmapFrame.Create(stream,
                                          BitmapCreateOptions.None,
                                          BitmapCacheOption.OnLoad);
    }
