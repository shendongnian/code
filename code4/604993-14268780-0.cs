    public TimeSpan RaiseTime
    {
        get { return (TimeSpan)GetValue(RaiseTimeProperty); }
        set { SetValue(RaiseTimeProperty, value); }
    }
    public static readonly DependencyProperty RaiseTimeProperty =
        DependencyProperty.Register("RaiseTime", typeof(TimeSpan), typeof(MainWindow),
                                    new PropertyMetadata(TimeSpan.Zero, OnRaiseTimeChanged));
    private static void OnRaiseTimeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        var owner = sender as MainWindow;
        owner.TotalTime = owner.RaiseTime + owner.FallTime;
    }
    public TimeSpan FallTime
    {
        get { return (TimeSpan)GetValue(FallTimeProperty); }
        set { SetValue(FallTimeProperty, value); }
    }
    public static readonly DependencyProperty FallTimeProperty =
        DependencyProperty.Register("FallTime", typeof(TimeSpan), typeof(MainWindow),
                                    new PropertyMetadata(TimeSpan.Zero, OnFallTimeChanged));
    private static void OnFallTimeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        var owner = sender as MainWindow;
        owner.TotalTime = owner.RaiseTime + owner.FallTime;
    }
    /// <summary>
    /// Read-only DP:
    /// http://msdn.microsoft.com/en-us/library/ms754044.aspx
    /// http://www.wpftutorial.net/dependencyproperties.html
    /// </summary>
    public TimeSpan TotalTime
    {
        get { return (TimeSpan)GetValue(TotalTimeProperty); }
        private set { SetValue(TotalTimePropertyKey, value); }
    }
    public static readonly DependencyPropertyKey TotalTimePropertyKey =
        DependencyProperty.RegisterReadOnly("TotalTime", typeof(TimeSpan), typeof(MainWindow),
                                            new PropertyMetadata(TimeSpan.Zero));
    public static readonly DependencyProperty TotalTimeProperty = TotalTimePropertyKey.DependencyProperty;
