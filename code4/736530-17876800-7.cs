    var image = new BitmapImage(new Uri(article.ImageURL));               
    image.ImageOpened += (s, e) =>
        {
            image.CreateOptions = BitmapCreateOptions.None;
            WriteableBitmap wb = new WriteableBitmap(image);
            MemoryStream ms = new MemoryStream();
            wb.SaveJpeg(ms, image.PixelWidth, image.PixelHeight, 0, 100);
            byte[] imageBytes = ms.ToArray();
        };
    NLBI.Thumbnail.Source = image;
