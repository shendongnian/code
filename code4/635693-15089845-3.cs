    static void Main()
    {
        const int SIZE = 1000000;
        const int K = 10;
        var random = new Random();
        var values = new double[SIZE];
        for (var i = 0; i < SIZE; i++)
            values[i] = random.NextDouble();
        // Test values
        values[SIZE/2] = 2.0;
        values[SIZE/4] = 3.0;
        values[SIZE/8] = 4.0;
        IEnumerable<double> result;
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        result = values.OrderByDescending(x => x).Take(K).ToArray();
        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedMilliseconds);
        stopwatch.Restart();
        result = values.GetTopValues(K).ToArray();
        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedMilliseconds);
    }
