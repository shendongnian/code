    System.Threading.Timer myTimer;
    // initialize timer
    myTimer = new Timer(TimerProc, null, 1000, Timeout.Infinite);
    void TimerProc(object state)
    {
        // do request here
        // then reset the timer
        myTimer.Change(1000, Timeout.Infinite);
    }
