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
          
    }
