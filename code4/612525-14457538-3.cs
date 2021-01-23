    var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(10) };
    timer.Tick += OnTimerTick;
    timer.Start();
    private void OnTimerTick(object sender, object args)
    {
        // Do something with pickup here...
    }
