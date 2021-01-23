    DispatcherTimer timer = new DispatcherTimer();
    timer.Interval = TimeSpan.FromMilliseconds(x); //x is the amount of milliseconds you want between each method call
    
    timer.Tick += (source, e) =>
    {
        method();
    };
    timer.Start();
