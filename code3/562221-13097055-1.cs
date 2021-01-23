    panel.Children.Add(
        new Rectangle()
        {
            Width = 100,
            Height = 100,
            Fill = new SolidColorBrush(
                Color.FromArgb(255, 255, 255, ColorFloatToByte(0.25f)))
        });
    panel.Children.Add(
        new Rectangle()
        {
            Width = 100,
            Height = 100,
            Fill = new SolidColorBrush(
                Color.FromScRgb(1.0f, 1.0f, 1.0f, 0.25f))
        });
