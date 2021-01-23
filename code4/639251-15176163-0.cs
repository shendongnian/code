    private DispatcherTimer timer;
    public MainWindow()
    {
        InitializeComponent();
        timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2.5) };
        timer.Tick += timer_Tick;
    }
    private void timer_Tick(object sender, EventArgs e)
    {
        // take screenshot here
    }
    private void checkBox_Checked(object sender, RoutedEventArgs e)
    {
        timer.Start();
    }
    private void checkBox_Unchecked(object sender, RoutedEventArgs e)
    {
        timer.Stop();
    }
