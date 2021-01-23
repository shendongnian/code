    DispatcherTimer timer = new DispatcherTimer();
    
    timer.Tick += timer_Tick;
    timer.Interval = = new TimeSpan(1, 0, 0); //once an hour
    timer.Start();
    
    void timer_Tick(object sender, EventArgs e)
    {
         //do your updates
    }
