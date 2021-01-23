    timer.Tick += Timer_TickInit;
    timer.Interval = 0;
    timer.Start();
        
    //...
    
    public void Timer_TickInit(object sender, EventArgs e)
    {
        timer.Stop();
        timer.Interval = SOME_INTERVAL;
        timer.Tick += Timer_Tick();
        timer.Start();
    }
    public void Timer_Tick(object sender, EventArgs e)
    {
      //your timer action code here
    }
