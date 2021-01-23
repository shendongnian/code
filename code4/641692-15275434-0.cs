    private Timer _tiffTimer;
    void Window1_Loaded(object sender, RoutedEventArgs e)
            {
                //throw new NotImplementedException();
                _tiffTimer = new Timer();
                _tiffTimer.Interval = 50;  // change interval to change performance
                _tiffTimer.Tick += new EventHandler(tiffTimer_Tick);
                _tiffTimer.Start();
    
            }
    
    void tiffTimer_Tick(object sender, EventArgs e)
            {
                //do your stuff here
               
            }
