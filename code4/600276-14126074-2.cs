    public void Delayed(int delay, Action action)
    {
        Timer timer = new Timer();
        timer.Interval = delay;
        timer.Tick += (s, e) => {
            action();
            timer.Stop();
        }
        timer.Start();
    }
