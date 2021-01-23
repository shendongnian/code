    public void startTimer()
    {
    DispatcherTimer timer = new DispatcherTimer();
    //Fire the Tick event every second
    timer.Interval = new TimeSpan(0, 0, 1);
    timer.Tick += timer_Tick();
    timer.Start();
    }
    void timer_Tick(object sender, object e)
    {
    //Do whatever you want ex, refresh the time and show it in an label
    }
