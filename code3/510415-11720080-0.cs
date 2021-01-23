    private void StartCloseTimer()
    {
        DispatcherTimer timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromSeconds(10d);
        timer.Tick += TimerTick;
        timer.Start();
    }
    private void TimerTick(object sender, EventArgs e)
    {
        DispatcherTimer timer = (DispatcherTimer)sender;
        timer.Stop();
        timer.Tick -= TimerTick;
        Close();
    }
