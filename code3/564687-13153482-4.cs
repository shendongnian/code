    int BetweenTicks = 100;
    _timer = new Timer(MyTimer_Tick, null, 0, BetweenTicks);
    
    private void ProcessTimerEvent(object obj)
    {
        if (Tick != null)
            Tick(this, EventArgs.Empty);
    }
    void MyTimer_Tick(object sender, EventArgs e)
    {
        if(value)
        {
            //this stop the timer because dueTime is -1
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            MyFunction();
            //this start the timer
            _timer.Change(BetweenTicks , BetweenTicks);
        }
    }
