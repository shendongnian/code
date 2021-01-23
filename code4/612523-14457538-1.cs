    var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(10) };
    timer.Tick += OnTimerTick;
    timer.Start();
    private void OnTimerTick(object sender, EventArgs args)
    {
        // Do something with pickup here...
    }
