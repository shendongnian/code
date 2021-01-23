    public static void ExecuteIn(int milliseconds, Action action)
    {
        var timer = new System.Windows.Forms.Timer();
        timer.Tick += (s, e) => action();
        timer.Interval = milliseconds;
        timer.Start();
    }
