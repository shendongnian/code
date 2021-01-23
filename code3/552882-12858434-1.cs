    Func<int,int> twice = x => x * 2;
    const int LOOP = 5000000; // 5M
    var watch = Stopwatch.StartNew();
    for (int i = 0; i < LOOP; i++)
    {
        twice.Invoke(3);
    }
    watch.Stop();
    Console.WriteLine("Invoke: {0}ms", watch.ElapsedMilliseconds);
    watch = Stopwatch.StartNew();
    for (int i = 0; i < LOOP; i++)
    {
        twice.DynamicInvoke(3);
    }
    watch.Stop();
    Console.WriteLine("DynamicInvoke: {0}ms", watch.ElapsedMilliseconds);
