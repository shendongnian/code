    Random rand = new Random();
    Timer mytimer = new Timer();
    
    private void fireTimerClick(object sender, EventArgs e)
    {
        mytimer.Tick += new EventHandler(TimerEventProcessor);
        mytimer.Interval = rand.Next(1000, 3000);
        mytimer.Enabled = true;
        mytimer.Start();
    }
    
    public void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
    {
        mytimer.Interval = rand.Next(1000, 3000);
    
        System.Diagnostics.Debug.WriteLine(DateTime.Now);
    }
