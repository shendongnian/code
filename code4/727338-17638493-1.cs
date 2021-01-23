    public static readonly DependencyProperty DateProperty =
        DependencyProperty.Register("Date", typeof(DateTime), typeof(DaiesContainer),
        new PropertyMetadata(DateTime.Now, DatePropertyChanged));
    public DateTime Date
    {
        get { return (DateTime)GetValue(DateProperty); }
        set { SetValue(DateProperty, value); }
    }
    private void DatePropertyChanged(DateTime date)
    {
        //...
    }
    private static void DatePropertyChanged(
        DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((DaiesContainer)d).DatePropertyChanged((DateTime)e.NewValue);
    }
