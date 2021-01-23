    var timer = new System.Timers.Timer(1000);
    timer.Elapsed += HandleTimerElapsed;
    timer.Start();
    ...
    private void HandleTimerElapsed(object s, ElapsedEventArgs e)
    {
        var t = (System.Timers.Timer)s;
        t.Stop();
        try {
            ... do some processing
        }
        finally { // make sure to enable timer again
            t.Start();
        } 
    }
