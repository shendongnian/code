    public void StartCheckin(int dueTime)
    {
        var t = new Timer(new TimerCallback(CancelCheckin));
        t.Change(dueTime, Timeout.Infinite);
    }
    private void CancelCheckin(object state)
    {
        // cancel checkin
        // dispose of timer
        ((Timer)state).Dispose();
    }
