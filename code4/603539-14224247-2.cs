    Timer _timer;
        
    public void StartTimer()
    {
        _timer = new Timer();
        _timer.Interval = 100; // 100 ms = 0.1 s
        _timer.Tick += new EventHandler(timer_Tick);
        _timer.Start();
    }
    void timer_Tick(object sender, EventArgs e)
    {
        myControl.Number = i;
    }
