    public MainPage()
    {
        InitializeComponent();
        this.Loaded += MainPage_Loaded;
    }
    void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        SystemTray.BackgroundColor = Colors.Cyan;
        SystemTray.ForegroundColor = Colors.Green;
    }
