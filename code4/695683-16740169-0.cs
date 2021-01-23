    public static DependencyProperty MinutesProperty =
        DependencyProperty.Register("Minutes", typeof(string), typeof(TimelineControl),
        new PropertyMetadata(OnMinutesChanged));
    
    private static void OnMinutesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        // Handle change here
    
        // For example, to call the my_method() method on the object:
        TimelineControl tc = (TimelineControl)d;
        tc.my_method();
    }
