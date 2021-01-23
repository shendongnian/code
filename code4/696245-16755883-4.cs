    public string MyText
    {
        get { return (string)GetValue(MyTextProperty); } //do NOT modify anything in here
        set { SetValue(MyTextProperty, value); }
    }
    public static readonly DependencyProperty MyTextProperty = DependencyProperty.Register("MyText", typeof(string), typeof(SimpleText), new FrameworkPropertyMetadata(null,
                                  FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                                  MyTextPropertyChangedCallback));
    private static void MyTextPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var source = d as SimpleText;
        source.MyText = e.NewValue.ToString();
    }
