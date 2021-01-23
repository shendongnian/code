    var timer = new DispatcherTimer();
    timer.Interval = TimeSpan.FromSeconds(1);
    timer.Tick += OnTimerTick;
    
    ...
    private void OnTimerTick(object sender, object e)
    {
        // do somthing
    }
