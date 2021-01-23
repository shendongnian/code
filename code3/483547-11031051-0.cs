    static System.Timers.Timer aTimer = new System.Timers.Timer();
        
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
            {
        
    aTimer.Enabled=false;
    
                IpCheck();
    
    aTimer.Enabled=true;
            }
    
            private static void EnableTimer()
            {
                // Set the Interval to x seconds.
                aTimer.Interval = 10000;
                aTimer.Enabled=true;
                
    
        
            }
    private static void DisableTimer()
    {
                
    
    aTimer.Elapsed -= new ElapsedEventHandler(OnTimedEvent);
    aTimer.Enabled = false;
        
        
    }
