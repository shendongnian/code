    // some code for the timer in your page
    timer = new DispatcherTimer {Interval = new TimeSpan(0, 0, 1)};
    timer.Tick += TimerOnTick;
    timer.Start();
    // event handler for the timer tick
    private void TimerOnTick(object sender, object o)
    {
        timer.Stop();
        var md = new MessageDialog("Test");
        this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => md.ShowAsync());
    }
