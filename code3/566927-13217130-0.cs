    private DispatcherTimer timer;
    public MainWindow()
    {
        InitializeComponent();
        timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
        timer.Tick += timer_Tick;
    }
    void timer_Tick(object sender, EventArgs e)
    {
        timer.Stop();
        MessageBox.Show("Mouse stopped moving");
    }
    private void Window_MouseMove(object sender, MouseEventArgs e)
    {
        timer.Stop();
        timer.Start();
    }
