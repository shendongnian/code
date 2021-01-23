        System.Timers.Timer aTimer;
        // Create a timer with a one second interval.
        aTimer = new System.Timers.Timer(1000);
        // Hook up the event handler for the Elapsed event.
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        // Only raise the event the first time Interval elapses.
        aTimer.AutoReset = false;
        aTimer.Enabled = true;  // uncommented this now
        //addded  below
        aTimer.Start();
