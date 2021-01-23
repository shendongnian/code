    // Start a stopwatch per tfb
    int tfb11Cnt = 0;
    Stopwatch sw11 = new Stopwatch();
    tfb11 = new TransformBlock<List<int>, List<int>>(item =>
    {
        if (Interlocked.CompareExchange(ref tfb11Cnt, 1, 0) == 0)
            sw11.Start();
                
        return item;
    });
    // [...]
    // completion
    Task.WhenAll(tfb11.Completion, tfb12.Completion).ContinueWith(_ =>
    {
                    
         Console.WriteLine("TransformBlocks 11 and 12 completed. SW11: {0}, SW12: {1}",
         sw11.ElapsedMilliseconds, sw12.ElapsedMilliseconds);
         transformManyBlock1.Complete();
    });
