    private _DispatcherTimer _timer;
    private int _spentTime;
    
    public Application()
    {
        _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
        _timer.Tick += TimerTick;
        _timer.Start();
    }
    
    TimerTick(object s, EventArgs args)
    {
        _spentTime++;
    }
