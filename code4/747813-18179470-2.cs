         //somewhere in your class 
         System.Timer.Timer tmr  = new System.Timers.Timer();
         //on construct or start event         
         tmr.Interval  = 1800000; //30 minutes = 60*1000*30
         tmr.Elapsed -= new ElapsedEventHandler(OnTimedEvent);
         tmr.Elapsed += new ElapsedEventHandler(OnTimedEvent);
         tmr.Start();
         private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
                tmr.Stop();
              ServiceController service = new ServiceController(yourserviceName);
              service.Stop();
             // service.Start() uncomment this line if your want to restart
         }
          protected override void OnStop()
        { 
             
        }
