    timer.Tick += Timer_Tick;
    timer.Interval = 0;
    timer.Start();
        
    //...
    
    public void Timer_Tick(object sender, EventArgs e)
    {
      if (timer.Interval == 0) {
        timer.Stop();
        timer.Interval = SOME_INTERVAL;
        timer.Start();
        return;
      }
      //your timer action code here
    }
