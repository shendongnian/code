    public static DependencyProperty AlternativeStyleProperty =
        DependencyProperty.Register(
            "AlternativeStyle",
            typeof(Style),
            typeof(MyUserControl));
    public Style AlternativeStyle
    {
        get { return (Style)GetValue(AlternativeStyleProperty); }
        set { SetValue(AlternativeStyleProperty, value); }
    }
    public static DependencyProperty IsSomethingProperty =
        DependencyProperty.Register(
            "IsSomething",
            typeof(bool),
            typeof(MyUserControl),
            new PropertyMetadata(true, IsSomethingProperty_Changed));
    public bool IsSomething
    {
        get { return (bool)GetValue(IsSomethingProperty); }
        set { SetValue(IsSomethingProperty, value); }
    }
    private static void IsSomethingProperty_Changed(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        // Swap styles
        // e.g.
        // var tempStyle = Style;
        // Style = AlternativeStyle;
        // AlternativeStyle = tempStyle;
    }
