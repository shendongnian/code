    int BetweenTicks = 100;
    _timer = new Timer(MyTimer_Tick, null, BetweenTicks , Timeout.Infinite);
    
    private void ProcessTimerEvent(object obj)
    {
        if (Tick != null)
            Tick(this, EventArgs.Empty);
        _timer.Change(BetweenTicks , Timeout.Infinite);
    }
