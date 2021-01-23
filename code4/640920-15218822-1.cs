    public void InitTimer()
    {
        System.Threading.Timer timer = new System.Threading.Timer(TimerProc);
        timer.Change(1000, 1000); // Start after 1 second, repeat every 1 seconds
    }
    public void TimerProc(object state)
    {
        // perform the operation
    }
