    private static void TimerTickHandler(object sender, EventArgs e)
    {
        Timer timer = (Timer)sender;
        timer.Stop();
        timer.Tick -= TimerTickHandler;
        ((Action)timer.Tag)();
    }
    
    public void Delayed(int delay, Action action)
    {
        Timer timer = new Timer { Interval = delay, Tag = action };
        timer.Tick += TimerTickHandler;
        timer.Start();
    }
