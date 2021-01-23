    //Note Forms.Timer and Timer() have similar implementations. 
    public static void DelayAction(int millisecond, Action action)
    {
        var timer = new DispatcherTimer();
        timer.Tick += delegate
        {
            action.Invoke();
            timer.Stop();
        };
        timer.Interval = TimeSpan.FromMilliseconds(millisecond);
        timer.Start();
    }
