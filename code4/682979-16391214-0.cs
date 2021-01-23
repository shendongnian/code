    public void StartTimer(object o, RoutedEventArgs sender)
    { 
        this.timer = new DispatcherTimer();
        // this is an easier way to specify TimeSpan durations
        timer.Interval = TimeSpan.FromMilliseconds(100);
        // you don't need the delegate wrapper
        timer.Tick += checkJson_Tick;
        timer.Start();
    }
    void checkJson_Tick(object sender, EventArgs e)
    {
        // ...
    }
