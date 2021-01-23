    using System.Timers;
    Timer timer = new Timer();
    timer.Interval  = 5000;   // in milliseconds
    timer.Elapsed  += delegate { elapsedEvent.Set(); }
    timer.AutoReset = false;  // again, I prefer manual control
    timer.Start();
