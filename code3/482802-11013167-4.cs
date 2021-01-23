    public static readonly DependencyProperty ItemsProperty = // <-- remove static
        DependencyProperty.Register("Items",
        typeof(Collection<UIElement>),
        typeof(MultiColumnStackPanel),
        new PropertyMetadata(new Collection<UIElement>()));
