    Console.WriteLine("{0} bits", IntPtr.Size == 4 ? 32 : 64);
    var cp = Process.GetCurrentProcess();
    cp.PriorityClass = ProcessPriorityClass.High;
    const int size = 10000000;
    int[] nums = new int[size];
    Parallel.For(0, size, i => { nums[i] = 1; });
    GC.Collect();
    GC.WaitForPendingFinalizers();
    long total = 0;
    {
        TimeSpan start = cp.TotalProcessorTime;
        Stopwatch sw = Stopwatch.StartNew();
        Parallel.For<long>(
            0, size, () => 0,
            (j, loop, subtotal) =>
            {
                return subtotal + nums[j];
            },
            (x) => Interlocked.Add(ref total, x)
        );
        sw.Stop();
        TimeSpan end = cp.TotalProcessorTime;
        Console.WriteLine("Parallel: Ticks: {0,10}, Total ProcessTime: {1,10}", sw.ElapsedTicks, (end - start).Ticks);
    }
    if (total != size)
    {
        Console.WriteLine("Error");
    }
    GC.Collect();
    GC.WaitForPendingFinalizers();
    total = 0;
    {
        TimeSpan start = cp.TotalProcessorTime;
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < size; ++i)
        {
            total += nums[i];
        }
        sw.Stop();
        TimeSpan end = cp.TotalProcessorTime;
        Console.WriteLine("Base    : Ticks: {0,10}, Total ProcessTime: {1,10}", sw.ElapsedTicks, (end - start).Ticks);
    }
    if (total != size)
    {
        Console.WriteLine("Error");
    }
    GC.Collect();
    GC.WaitForPendingFinalizers();
    total = 0;
    Func<int, int, long, long> adder = (j, loop, subtotal) =>
    {
        return subtotal + nums[j];
    };
    {
        TimeSpan start = cp.TotalProcessorTime;
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < size; ++i)
        {
            total = adder(i, 0, total);
        }
        sw.Stop();
        TimeSpan end = cp.TotalProcessorTime;
        Console.WriteLine("Func    : Ticks: {0,10}, Total ProcessTime: {1,10}", sw.ElapsedTicks, (end - start).Ticks);
    }
    if (total != size)
    {
        Console.WriteLine("Error");
    }
