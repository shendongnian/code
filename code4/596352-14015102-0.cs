    DispatcherTimer timer = new DispatcherTimer();
    timer.Tick += {
        statusbox.Text = "";
        timer.Stop();
    };
    timer.Interval = TimeSpan.FromSeconds(4);
    timer.Start();
