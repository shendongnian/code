    System.Timers.Timer _timer = new System.Timers.Timer();
    _timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    _timer.Interval = 60000;
    _timer.Enabled = true;
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
       // add your code here
    }
