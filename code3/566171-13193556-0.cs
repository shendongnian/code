    var timer = new System.Timers.Timer();    
    timer.Elapsed += new ElapsedEventHandler(TimerElapsed);
    timer.Interval = 60 * 60 * 1000; // 1 hour
    timer.Enabled = true;
    ...
    private static void TimerElapsed(object source, ElapsedEventArgs e)
    {
        // check disk space
    } 
