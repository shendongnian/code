    public string MyName
    {
        get { return (string)GetValue(MyNameCustomProperty); }
        set { SetValue(MyNameCustomProperty, value); }
    }
    public static DependencyProperty MyNameCustomProperty = DependencyProperty.Register("MyName", typeof(string), typeof(MyTabControl), new PropertyMetadata("", MyPropertyChanged, CoerceCurrentReading));
    private static void MyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        //contains coerced value
    }
    private static object CoerceCurrentReading(DependencyObject d, object value)
    {
        MyTabControl tab = (MyTabControl)d;
        return (string)value + " World";
    }
