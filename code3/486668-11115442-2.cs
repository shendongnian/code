    protected override void OnStart(string[] args)
    {
       log.Info("Info - Service Start");
       DateTime startTime = DateTime.Date.AddHours(9); //9AM Today
       timeToRun.Add(startTime); 
       CreateTimer();
    }
    void CreateTimer()
    {
       log.Info("Info - Reset Timer");
       try
       {
          if(_timer == null){
             _timer = new Timer(3600 * 1000); //once an hour
             _timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
             _timer.Start();
          }
        }
        catch (Exception ex)
        {
            log.Error("This is my timer error - ", ex);
        }
    }
