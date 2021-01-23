    double GetFreq(long time, out int highCount, out int lowCount)
    {
        const int ADDRESS = 0x378 + 1, MASK = 0x10;
        highCount = lowCount = 0;
        bool LastState = (Input(ADDRESS) & MASK) == MASK;
        if (LastState)
        {
            highCount++;
        }
        else
        {
            lowCount++;
        }
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        while (stopwatch.ElapsedMilliseconds <= time)
        {
            if ((Input(ADDRESS) & MASK) == MASK) // High
            {
                if (!LastState)
                {
                    highCount++;
                    LastState = true;
                }
            }
            else
            {
                if (!LastState)
                {
                    lowCount++;
                    LastState = false;
                }
            }
        }
        stopwatch.Stop();
        return ((double)(highCount + lowCount)) / time * 500
    }
