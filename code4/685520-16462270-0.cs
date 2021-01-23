    Timer timer;
    public Form1()
    {
        InitializeComponent();
        timer.Tick += new EventHandler(timer_Tick); // when timer ticks, timer_Tick will be called
        timer.Interval = (1000) * (10);             // Timer will tick every 10 seconds
        timer.Enabled = true;                       // Enable the timer
        timer.Start();                              // Start the timer
    }
    void timer_Tick(object sender, EventArgs e)
    {
        double sec = stopWatch.ElapsedMilliseconds / 1000;
        double min = sec / 60;
        double hour = min / 60;
        if (hour == 9.00D)
        {
            stopWatch.Stop();
            MessageBox.Show("passed: " + hour.ToString("0.00"));
        }
    }
