    private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
    {
        if (DelayedAction(100, sender))
            UpdateAnnotations();
    }
    
    Dictionary<object, Timer> timers = new Dictionary<object, Timer>();
    bool DelayedAction(int delay, object o)
    {
        if (timers.ContainsKey(o))
            return false;
    
        var timer = new Timer();
        timer.Interval = delay;
        timer.Tick += (s, e) =>
            {
                timer.Stop();
                timer.Dispose();
                lock(timers)
                    timers.Remove(o);
            };
    
        lock(timers)
            timers.Add(o, timer);
        timer.Start();
        return true;
    }
