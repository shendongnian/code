    System.Windows.Threading.DispatcherTimer dt; //declaration outside the method
    private void temperatureTimer()
    {
        dt = new System.Windows.Threading.DispatcherTimer(); //initialization inside a method
        dt.Interval = new TimeSpan(0, 0, 1, 0, 0); 
        dt.Tick += new EventHandler(dt_Tick);
        dt.Start();
    }
    private void turnoff() //now your this method will work to stop the timer
    { 
        dt.stop();
    }
