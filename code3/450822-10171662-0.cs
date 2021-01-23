    protected override void OnStart(string[] args)
    {
        const int period = 30 * 1000;
        Timer timer = new Timer(TimerCallback, null, 0, period);
    }
    
    private void TimerCallback(object state)
    {
        // Polling goes here
    }
