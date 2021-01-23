    var timer = new System.Timers.Timer
    {
        Interval = 400,
        AutoReset = true
    };
    timer.Elapsed += (_, __) => Console.WriteLine("Stayin alive (2)...");
    timer.Enabled = true;
    WeakReference weakTimer = new WeakReference(timer);
    timer = null;
    for (int i = 0; i < 100; i++)
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
    Console.WriteLine("Weak Reference: {0}", weakTimer.Target);
    Console.ReadKey();
