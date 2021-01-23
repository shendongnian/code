    public FrameworkElement View
    {
        get { return (FrameworkElement)GetValue(ContentProperty); }
        set
        {
            SetValue(ContentProperty, value);
        }
    }
