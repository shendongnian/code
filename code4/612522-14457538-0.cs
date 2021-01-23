    var timer = new DispatchTimer { Interval = TimeSpan.FromSeconds(10) };
    timer.Tick += OnTimerTick;
    timer.Start();
    private void OnTimerTick(object sender, EventArgs args)
    {
        // Do something here.
    }
