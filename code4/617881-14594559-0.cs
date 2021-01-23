    var timer = new DispatcherTimer
    {
        Interval = TimeSpan.FromSeconds(0.5)
    };
    
    timer.Tick += (s, e) => ((RotateTransform)ImageWheel.RenderTransform).Angle += 15;
    timer.IsEnabled = true;
