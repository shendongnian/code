    public static readonly DependencyProperty SampleProperty =
                                              DependencyProperty.RegisterAttached("Sample",
                                              typeof(bool),
                                              typeof(SampleClass),
                                              new UIPropertyMetadata(false, OnSample));
    private static void OnSample(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue is bool && ((bool)e.NewValue) == true)
        {
            // do something...
        }
    }
