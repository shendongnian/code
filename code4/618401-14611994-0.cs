    public void StartTimer()
    {
        System.Threading.Thread.Sleep(10000);
        System.Windows.Threading.DispatcherTimer myDispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        myDispatchTimer.Interval = TimeSpan.FromSeconds(10); // initial 10 second wait
        myDispatchTimer.Tick += new EventHandler(Initial_Wait);
        myDispatchTimer.Start();
    }
    void Initial_Wait(object o, EventArgs sender)
    {
        // Stop the timer, replace the tick handler, and restart with new interval.
        myDispatchTimer.Stop();
        myDispatchTimer.Tick -= new EventHandler(Initial_Wait);
        myDispatcherTimer.Interval = TimeSpan.FromSeconds(interval); //every x seconds
        myDispatcherTimer.Tick += new EventHandler(Each_Tick);
        myDispatcherTimer.Start();
    }
