    private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
    {
        DelayedAction(UpdateAnnotations, 100, sender);
    }
    
    Dictionary<object, Timer> timers = new Dictionary<object, Timer>();
    void DelayedAction(Action action, int delay, object o)
    {
        if (timers.ContainsKey(o))
            return;
    
        var timer = new Timer();
        timer.Interval = delay;
        timer.Tick += (s, e) =>
            {
                action();
                timer.Stop();
                timer.Dispose();
                timers.Remove(o);
            };
    
        timers.Add(o, timer);
        timer.Start();
    }
