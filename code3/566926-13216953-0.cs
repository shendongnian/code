    private void poc_MouseMove(object sender, MouseEventArgs e)
    {
       if (timer != null)
       {
          timer.Tick-= timer_Tick;
       }
       timer = new DispatcherTimer();
       timer.Interval = new TimeSpan(0, 0, 5);
       timer.Tick += new EventHandler(timer_Tick);
       timer.Start();
    }
