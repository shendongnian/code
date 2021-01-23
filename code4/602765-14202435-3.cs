    // Constructor
    public MainPage()
    {
        InitializeComponent();
        timer.Text = "30";
        tmr.Interval = TimeSpan.FromSeconds(1);
        tmr.Tick += OnTimerTick;
    }
    private void trigger(object sender, RoutedEventArgs e)
    {
            resetTimer();
            tmr.Start();
    }
