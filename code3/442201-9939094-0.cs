         Private Boolean eOccured = False;
         System.Timers.Timer aTimer = new System.Timers.Timer();
         aTimer.Elapsed+=new ElapsedEventHandler(OnTimedEvent);
         aTimer.Interval = 600000; //milliseconds(10 min)
         aTimer.Enabled = True;
