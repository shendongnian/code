    _bi = new BitmapImage(new Uri("http://blog.webnames.ca/images/Godzilla.png", UriKind.Absolute));
    _bi.ImageOpened += ImageOpened;
    ...
    private void ImageOpened(object sender, RoutedEventArgs e)
    {
        var isf = IsolatedStorageFile.GetUserStoreForApplication();
        using (var writer = new StreamWriter(new IsolatedStorageFileStream("godzilla.png", FileMode.Create, FileAccess.Write, isf)))
        {
            var encoder = new PngEncoder();
            var wb = new WriteableBitmap(_bi);
            encoder.Encode(wb.ToImage(), writer.BaseStream);
        }
    }
