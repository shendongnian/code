    public static readonly DependencyProperty FillColorProperty = DependencyProperty.Register(
        "FillColor",
        typeof(Brush),
        typeof(Compressor), // <- ERROR ! should be typeof(PercentFiller)
        new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 134, 134, 134))));
