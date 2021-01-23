    using (System.Timers.Timer NewTimer = new System.Timers.Timer())
    {
        NewTimer.AutoReset = false;
        ElapsedEventHandler TimerElapsed = (sender, args) => { Console.Out.WriteLine("called!!!"); };
        NewTimer.Elapsed += new ElapsedEventHandler(TimerElapsed);
        NewTimer.Interval = 1000;
        NewTimer.Start();
    }
    
    Thread.Sleep(3000);
