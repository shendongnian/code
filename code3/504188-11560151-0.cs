    System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
    dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
    dispatcherTimer.Interval = new TimeSpan(0,5,0);
    dispatcherTimer.Start();
    
    
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
      // code goes here
    }
