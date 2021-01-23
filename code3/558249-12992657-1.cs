    static Tile()
    {
        ContentProperty.OverrideMetadata(typeof(Tile), new PropertyMetadata(null, OnContentChanged));
    }
    private static void OnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        // Your logic goes here.
    }
