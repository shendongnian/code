    Parallel.ForEach(Enumerable.Range(0, 7), i =>
    {
        Thread.Sleep(5000);
        Console.WriteLine(i + " done!");
    });
    Console.WriteLine("All done!");
