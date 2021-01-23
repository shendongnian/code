    public string myText
    {
        get { return (string)GetValue(myTextProperty); }
        set { SetValue(myTextProperty, value); }
    }
    // Using a DependencyProperty as the backing store for myText.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty myTextProperty =
        DependencyProperty.Register("myText", typeof(string), typeof(Window1), new PropertyMetadata(null));
