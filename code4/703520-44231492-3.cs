    public static readonly DependencyProperty RelativeProperty = 
        DependencyProperty.RegisterAttached("Relative", typeof(double), typeof(MyControl));
    public static double GetRelative(DependencyObject o)
    {
        return (double)o.GetValue(RelativeProperty);
    }
    public static void SetRelative(DependencyObject o, double value)
    {
        o.SetValue(RelativeProperty, value);
    }
