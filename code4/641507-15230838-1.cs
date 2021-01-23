    private static Timer _myTimer = new Timer();
    // ...
    private static void OnTick(Object obj, EventArgs args)
    {
        fileSystemWatcher.EnableRaisingEvents ^= true;
    }
    
    // ...
    _myTimer.Tick += OnTick;
    _myTimer.Interval = 100;
    _myTimer.Start();
