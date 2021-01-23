    System.Windows.Threading.DispatcherTimer dt = new System.Windows.Threading.DispatcherTimer();
     
    dt.Interval = TimeSpan.FromMilliseconds(500);
    dt.Tick +=new EventHandler(dt_Tick);
    
    void dt_Tick(object sender, EventArgs e)
    {
           //code
    }
