    public void SetImage()
    {
        var uri = new Uri("pack://application:,,,/images/image.png");
        var bitmap = new BitmapImage(uri);
        var image = new Image { Source = bitmap };
        panel.Children.Add(image);
    }
