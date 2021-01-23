    public static void TryTwo() // fails
    {
        var line = new Line {A = 3, B = 5};
        var dict = integers.ToDictionary<int, int, decimal>(i => i, line.Compute);
        Console.WriteLine("TryTwo complete");
    }
    public static void TryFive() // works
    {
        var line = new Line { A = 3, B = 5 };
        Func<int, decimal> func = line.Compute;
        var dict = integers.ToDictionary<int, int, decimal>(i => i, func);
        Console.WriteLine("TryFour complete");
    }
