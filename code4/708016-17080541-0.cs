    //Create the timer
    DispatcherTimer timer = new DispatcherTimer();
    timer.Interval = TimeSpan.FromSeconds(3);
    timer.Tick += TimerOnTick;
    
    // the subscription method
    private void TimerOnTick(object sender, EventArgs eventArgs)
    {
        Clipboard.SetText("");
    }
