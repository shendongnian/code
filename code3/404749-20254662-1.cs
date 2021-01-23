    public static void SetTimeout(Action callback, int milliseconds)
    {
        Timer t = null;
        t = new Timer((state) => { t.Dispose(); callback(); }, null, dueTime: milliseconds, period: Timeout.Infinite);
    }
    public static Timer SetInterval(Action callback, int milliseconds)
    {
        return new Timer((state) => { callback(); }, null, dueTime: milliseconds, period: milliseconds);
    }
    public static void ClearInterval(Timer t)
    {
        t.Dispose();
    }
