    //Object that holds timer state, and possible additional data
    private class TimerState
    {
        public Timer Timer { get; set; }
        public bool Stop { get; set; }
    }
    public void Run()
    {
        var timerState = new TimerState();
        //Create the timer but don't start it
        timerState.Timer = new Timer(OnTimer, timerState, Timeout.Infinite, Timeout.Infinite);
        //Start the timer
        timerState.Timer.Change(1000, Timeout.Infinite);
    }
    public void OnTimer(object state)
    {
        var timerState = (TimerState) state;            
        try
        {
            //Do work
        }
        finally 
        {
            //Reschedule timer
            if (!timerState.Stop)
                timerState.Timer.Change(1000, Timeout.Infinite);
        }
    }
