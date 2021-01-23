    public MainPage()
    {
        InitializeComponent();
        this.Loaded += MainPage_Loaded;
    }
    void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        Microsoft.Phone.Shell.SystemTray.BackgroundColor = Colors.Cyan;
        Microsoft.Phone.Shell.SystemTray.ForegroundColor = Colors.Green;
    }
