    private readonly ConcurrentDictionary<string, Timer> _delayedActionTimers = new ConcurrentDictionary<string, Timer>();
    private static readonly TimeSpan _noPeriodicSignaling = TimeSpan.FromMilliseconds(-1);
    
    public void DelayedAction(Action delayedAction, string key, TimeSpan actionDelayTime)
    {
        Func<Action, Timer> timerFactory = action =>
            {
                var timer = new Timer(state =>
                    {
                        var t = state as Timer;
                        if (t != null) t.Dispose();
                        action();
                    });
                timer.Change(actionDelayTime, _noPeriodicSignaling);
                return timer;
            };
    
        _delayedActionTimers.AddOrUpdate(key, s => timerFactory(delayedAction),
            (s, timer) =>
                {
                    timer.Dispose();
                    return timerFactory(delayedAction);
                });
    }
