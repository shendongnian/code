        double size = 14.0;
        BitmapImage bmp = new BitmapImage(new Uri("MyIcon.ico", UriKind.RelativeOrAbsolute));
        FrameworkElementFactory icon = new FrameworkElementFactory(typeof(Image));
        icon.SetValue(Image.SourceProperty, bmp);
        icon.SetValue(Image.WidthProperty, size);
        icon.SetValue(Image.HeightProperty, size);
