    Stopwatch w = new Stopwatch()
    long nextTick = 0;
    long ticksPerMicroSecond = 1000000L / Stopwatch.Frequency; // Number of ticks per microsec.
    long periodInTicks = ticksPerMicroSecond / 100; // Ticks per 0.1ms
    while(true)
    {
      long currentTick = w.ElapsedTicks.
      if (currentTick  > nextTick)
      {
        nextTick = currentTick + periodInTicks;
        // Do something here.
      }
    }
