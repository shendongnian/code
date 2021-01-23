    private void InitTimer()
    {
        timer = new DispatcherTimer();
        timer.Interval = new TimeSpan(0,0,0,1);
        timer.Tick += timer_Tick;
    }
    private void StartTimer()
    {
        timer.Start();
    }
