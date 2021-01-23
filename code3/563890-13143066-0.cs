    System.Timers.Timer sqlTimer = new System.Timers.Timer();
    sqlTimer.Interval = 60000; // One minute
    sqlTimer.AutoReset = false; // Fire only once
    sqlTimer.Elapsed = TimerEvent; // Assign event for timer
    sqlTimer.Start(); // Start the timer
