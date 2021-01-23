    public static readonly DependencyProperty EnvironmentObjectProperty =
        DependencyProperty.Register(
            "EnvironmentObject",
            typeof(Framework.Environment),
            typeof(EnvironmentStateView),
            new PropertyMetadata(null));
