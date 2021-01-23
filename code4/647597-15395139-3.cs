    double[,] d = new double[5, 5]
    {
        { 0, 1, 2, 3, 4 },
        { 5, 6, 7, 8, 9 },
        { 10, 11, -10, 12, 13 },
        { 14, 15, 16, 17, 18 },
        { 19, double.NaN, 21, 22, 23 }
    };
    Console.WriteLine(d.Min());
    Console.WriteLine(d.Min(double.NaN));
