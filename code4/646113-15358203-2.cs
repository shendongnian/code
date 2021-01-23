    DispatcherTimer dispathcerTimer = new DispatcherTimer();
    dispathcerTimer.Interval = TimeSpan.FromMinutes(2);
    dispathcerTimer.Tick += dispathcerTimer_Tick;
    dispathcerTimer.Start();
    void dispatcherTime_Tick(object sender, object e)
    {
      //function, which needs to be invoked every two minutes.     
    }
