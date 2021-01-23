         //somewhere in your class 
         System.Timer.Timer tmr  = new System.Timers.Timer();
         //on construct or start event
         tmr.Interval  = yourdesiredInterval();
         tmr.Elapsed += new ElapsedEventHandler(OnTimedEvent);
         tmr.Start();
         private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
              yourservice.Stop();
         }
          protected override void OnStop()
        { 
              tmr.Reset();
        }
