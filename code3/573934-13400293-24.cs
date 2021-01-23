    Stopwatch sw = new Stopwatch();
    long totalMicroseconds = 0;
    int numItems = 1000;
    for(int i = 0; i < numItems; i++)
    {
        sw.Reset();
        sw.Start();
        OneItemDelivery();
        sw.Stop();
        totalMicroseconds += sw.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L));
    }
    long avgOneItemDelivery = totalMicroseconds/numItems;
