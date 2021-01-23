    public static readonly DependencyProperty SystemProperty = DependencyProperty.Register(
            "System",
            typeof(ServerGroup),
            typeof(ServerGroupControlViewModel),
            new PropertyMetadata
            {
                PropertyChangedCallback = SystemPropertyChanged
            }
        );
    static void SystemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ServerGroupControlViewModel receiver = (ServerGroupControlViewModel)d;
        ServerGroup newValue = e.NewValue as ServerGroup;
        
        // Add any appropriate handling logic here.
    }
