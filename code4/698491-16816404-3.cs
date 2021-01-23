    private void StatusBarFade(string message)
    {
        statusBar.Content = message;
        var animation = new ColorAnimation
        {
            From = Colors.Gold,
            To = Colors.Black,
            AutoReverse = true,
            Duration = TimeSpan.FromSeconds(0.1),
            RepeatBehavior = new RepeatBehavior(TimeSpan.FromSeconds(1.5)),
        };
        statusBar.Foreground = new SolidColorBrush();
        statusBar.Foreground.BeginAnimation(SolidColorBrush.ColorProperty, animation);
        var timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(4.5)
        };
        timer.Tick +=
            (o, e) =>
            {
                timer.Stop();
                statusBar.Content = string.Empty;
            };
        timer.Start();
    }
