    public ICommand comInitialiseWindows
    {
        get { return (ICommand)GetValue(MyPropertyProperty); }
        set { SetValue(MyPropertyProperty, value); }
    }
    
    public static readonly DependencyProperty comInitialiseWindowsProperty = 
        DependencyProperty.Register("comInitialiseWindows", typeof(ICommand), typeof(MainWindow), new PropertyMetadata(null));
