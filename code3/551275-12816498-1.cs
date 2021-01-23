    const double desiredFps = 500.0;
    long ticks1 = 0;
    var interval = Stopwatch.Frequency / desiredFps;
    while (true)
    {
        Application.DoEvents();
        var ticks2 = Stopwatch.GetTimestamp();
        if (ticks2 >= ticks1 + interval)
        {
            ticks1 = Stopwatch.GetTimestamp();
            // do the drawing here
        }
    }
