      Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
    for(int i= 0; i <= 90000; i++)
    {
        // Get the elapsed time as a TimeSpan value.
        TimeSpan ts = stopWatch.Elapsed;
    if(ts.Seconds >= 60)
      break;
    }
