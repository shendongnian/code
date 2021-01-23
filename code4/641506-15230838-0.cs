    private static bool _raiseEvent = true;
    private static Timer _myTimer = new Timer();
    // ...
    private static void OnTick(Object obj, EventArgs args)
    {
        _raiseEvent = !_raiseEvent;
    }
    
    private static void MyEvent(Object obj, EventArgs args)
    {
        if (raiseEvent == false) return;
    }
    // ...
    _myTimer.Tick += OnTick;
    _myTimer.Interval = 100;
    _myTimer.Start();
