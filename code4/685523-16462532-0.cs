    Timer timer;
    public Form1()
    {
        InitializeComponent();
        timer.Tick += timer_Tick;
        timer.Interval = TimeSpan.FromHours(9).TotalMilliseconds;
        timer.Start();
    }
    
    void timer_Tick(object sender, EventArgs e)
    {
        timer.Stop();
        MessageBox.Show("9 hours passed");
    }
