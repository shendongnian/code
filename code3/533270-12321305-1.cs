    Task<int>[] tasks = new Task<int>[]
    {
        Task.Factory.StartNew<int>(()=>
            {
                Thread.Sleep(10000);
                return 1;
            }),
        Task.Factory.StartNew<int>(()=>
            {
                Thread.Sleep(3000);
                return 2;
            })
    };
    TimeSpan timeSpan = new TimeSpan(0, 0, 5);
    var stopwatch = Stopwatch.StartNew();
    Task.WaitAll(tasks, timeSpan);
    Console.WriteLine("WaitAll took {0} seconds", stopwatch.Elapsed.TotalSeconds);
    int[] results = new int[tasks.Length];
    for (int i = 0; i < tasks.Length; i++)
    {
        stopwatch = Stopwatch.StartNew();
        Console.WriteLine(tasks[i].Result);
        Console.WriteLine("Printing result took {0} seconds", stopwatch.Elapsed.TotalSeconds);
    }
