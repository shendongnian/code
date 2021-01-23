    public static readonly DependencyProperty LineSpacingProperty =
        DependencyProperty.Register("LineSpacing", typeof(double), typeof(TextView),
                                    new FrameworkPropertyMetadata(1.0));
    public double LineSpacing {
        get { return (double) GetValue(LineSpacingProperty); }
        set { SetValue(LineSpacingProperty, value); }
    }
