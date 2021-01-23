    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(
            "Value", typeof(string), typeof(FooView),
            new PropertyMetadata(ValuePropertyChanged));
    private static ValuePropertyChanged(DependencyObject obj,
        DependencyPropertyChangedEventArgs e)
    {
        // obj is your FooView
        // get new property value from e.NewValue
    }
     
