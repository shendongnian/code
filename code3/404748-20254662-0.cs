    public static void SetTimeout(Action callback, int milliseconds)
    {
        new Timer((state) => { callback(); }, null, Timeout.Infinite, Timeout.Infinite)
            .Change(milliseconds, Timeout.Infinite); // "Change" will start the timer
    }
