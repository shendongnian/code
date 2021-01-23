    If(timer == null)
    {
        timer = new System.Timers.Timer();
        timer.AutoReset = false;
        timer.Interval = yourinterval;
        timer.Elapsed += new System.Timers.ElapsedEventHandler(DoStuff); 
    }
    timer.Start();
