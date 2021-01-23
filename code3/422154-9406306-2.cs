    Parallel.ForEach(Enumerable.Range(1, 8),
        i =>
        {
            Thread.Sleep(5000);
            Console.WriteLine(i + " done!");
        });
    Console.WriteLine("All done!");
