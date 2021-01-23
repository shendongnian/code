    var bitmap = new BitmapImage(new Uri(...));
    if (bitmap.Width > bitmap.Height)
    {
        image.Width = 475;
        image.Height = image.Width * bitmap.Height / bitmap.Width;
    }
    else
    {
        image.Height = 475;
        image.Width = image.Height * bitmap.Width / bitmap.Height;
    }
    image.Stretch = Stretch.Uniform;
    image.Source = bitmap;
