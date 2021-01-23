    Cherry cherry = new Cherry();
    // Create host for BitmapImage
    Image imageHost = new Image { Source = cherry.FruitImage };
    GameCanvas.Children.Add(imageHost);
    // Animate Image
    imageHost.BeginAnimation(Canvas.TopProperty, new DoubleAnimation(-150, 500, new Duration(TimeSpan.FromSeconds(5))));
