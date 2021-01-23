    static void Main()
    {
        var random = new Random(42);
        double[] x = Enumerable.Range(0, 10000).Select(_ => random.NextDouble()).ToArray();
        double[] y = Enumerable.Range(0, 10000).Select(_ => random.NextDouble()).ToArray();
        // make sure JIT doesn't affect the results
        SumProduct(x, y);
        SumProductLength(x, y);
        SumProductPointer(x, y);
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 0; i < 10000; i++)
        {
            SumProduct(x, y);
        }
        Console.WriteLine(stopwatch.ElapsedMilliseconds);
        stopwatch.Restart();
        for (int i = 0; i < 10000; i++)
        {
            SumProductLength(x, y);
        }
        Console.WriteLine(stopwatch.ElapsedMilliseconds);
        stopwatch.Restart();
        for (int i = 0; i < 10000; i++)
        {
            SumProductPointer(x, y);
        }
        Console.WriteLine(stopwatch.ElapsedMilliseconds);
    }
    private static double SumProduct(double[] X, double[] Y)
    {
        double sum = 0;
        int length = X.Length;
        if (length != Y.Length)
            throw new ArgumentException("X and Y must be same size");
        for (int i = 0; i < length; i++)
            sum += X[i] * Y[i];
        return sum;
    }
    private static double SumProductLength(double[] X, double[] Y)
    {
        double sum = 0;
        if (X.Length != Y.Length)
            throw new ArgumentException("X and Y must be same size");
        for (int i = 0; i < X.Length; i++)
            sum += X[i] * Y[i];
        return sum;
    }
    private static unsafe double SumProductPointer(double[] X, double[] Y)
    {
        double sum = 0;
        int length = X.Length;
        if (length != Y.Length)
            throw new ArgumentException("X and Y must be same size");
        fixed (double* xp = X, yp = Y)
        {
            for (int i = 0; i < length; i++)
                sum += xp[i] * yp[i];
        }
        return sum;
    }
