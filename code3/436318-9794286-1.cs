    myTimer = new System.Timers.Timer();
    myTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    myTimer.Interval = 5000;
    myTimer.AutoReset = false;
    myTimer.Start();
