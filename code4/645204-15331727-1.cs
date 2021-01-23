    public static Main(string[] args)
    {
        double test = 1.0/3;
        double prev = PrevDouble(test);
        Console.WriteLine("{0}, {1}, {2}", test, prev, test - prev);
    }
