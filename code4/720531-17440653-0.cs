     System.Timers.Timer aTimer = new System.Timers.Timer();
             aTimer.Elapsed+=new ElapsedEventHandler(OnTimedEvent);
             // Set the Interval to 1 millisecond.  Note: Time is set in Milliseconds
             aTimer.Interval=1;
             aTimer.Enabled=true;
 
