    private DispatcherTimer positionTimer;
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        // Create a timer that will check your condition (every second for example)
        positionTimer= new DispatcherTimer();
        positionTimer.Interval = TimeSpan.FromSeconds(1);
        positionTimer.Tick += new EventHandler(positionTimerTick);
        positionTimer.Start();
        mediaElement1.Play();
        button1.IsEnabled = false;
    }
    void positionTimerTick(object sender, EventArgs e)
    {
        if (mediaElement1.Position.TotalSeconds >= sometime)
        {
            // do something
        }
    }
