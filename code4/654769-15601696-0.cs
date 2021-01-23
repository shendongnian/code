    using (DrawingContext dc = ActiveImage.imageDV.RenderOpen())
    {
        var bitmap = new BitmapImage(new Uri(ActiveImage.imagePath));
        // alternatively, if it is a relative path
        // var bitmap = new BitmapImage(new Uri(ActiveImage.imagePath), UriKind.Relative);
        dc.DrawImage(bitmap, new Rect(ActiveImage.position, ActiveImage.size));
    }
