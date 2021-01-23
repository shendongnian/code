    _timer = new Timer(MyTimer_Tick, null, 1, Timeout.Infinite);
    
    private void ProcessTimerEvent(object obj)
    {
        if (Tick != null)
            Tick(this, EventArgs.Empty);
        _timer.Change(1, Timeout.Infinite);
    }
