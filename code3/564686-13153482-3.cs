    private void ProcessTimerEvent(object obj)
    {
        _timer.Change(Timeout.Infinite, Timeout.Infinite);
        if (Tick != null)
            Tick(this, EventArgs.Empty);
        _timer.Change(BetweenTicks , 5);
    }
