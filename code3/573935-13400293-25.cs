    sw.Start();
    for(int i = 0; i < numItems; i++)
    {
        OneItemDelivery();    
    }
    sw.Stop();
    totalMicroseconds = sw.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L));
    long avgOneItemDelivery = totalMicroseconds/numItems;
