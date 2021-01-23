    public TheClass()
    {
        timer.Tick += timer_Tick; 
        timer.Interval = new TimeSpan(00, 1, 1);
        timer.Start();
    }
