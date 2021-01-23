    private void clicked(object sender, RoutedEventArgs e)
    {
        draw();
        ........
        if (flag)
        {
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
            timer.Tick += (sender, args) => { timer.Stop(); draw(); };
            timer.Start();
        }
    }
