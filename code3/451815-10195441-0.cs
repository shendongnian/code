    DispatcherTimer dt = new DispatcherTimer();
    dt.Tick += new EventHandler(timer_Tick);
    dt.Interval = new TimeSpan(1, 0, 0); // execute every hour
    dt.Start();
    
    // Tick handler    
    private void timer_Tick(object sender, EventArgs e)
    {
        // code to execute periodically
    }
