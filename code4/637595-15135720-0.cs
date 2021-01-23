    private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
    {
        DelayedAction(UpdateAnnotations, TimeSpan.FromMilliseconds(1000), sender);
    }
    Dictionary<object, System.Timers.Timer> timers = new Dictionary<object, System.Timers.Timer>();
    void DelayedAction(Action action, TimeSpan delay, object o)
    {
        if (timers.ContainsKey(o))
            return;
        var timer = new System.Timers.Timer(delay.TotalMilliseconds);
        timer.Elapsed += (s, e) =>
            {
                timer.Stop();
                timer.Dispose();
                timers.Remove(o);
            };
        action();
        timers.Add(o, timer);
        timer.Start();
    }
