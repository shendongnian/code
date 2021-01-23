    //Inside Page Load 
    System.Windows.Threading.DispatcherTimer dt = new System.Windows.Threading.DispatcherTimer();
    dt.Interval = new TimeSpan(0, 0, 0, 0, 500); // 500 Milliseconds
    dt.Tick += new EventHandler(dt_Tick);
    
