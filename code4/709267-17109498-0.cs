    // First off, initialize the timer
    _timer = new System.Threading.Timer(OnTimedEvent, null,
        Timeout.Infinite, Timeout.Infinite);
    // Then, each time when door opens, start/reset it by changing its dueTime
    _timer.Change(5000, Timeout.Infinite);
    // And finally stop it in the event handler
    void OnTimedEvent(object obj)
    {
        _timer.Change(Timeout.Infinite, Timeout.Infinite);
        Console.WriteLine("All doors are closed because of timer");
    }
