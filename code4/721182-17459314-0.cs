    Random number = new Random();
    int min = int.MaxValue, max = int.MinValue;
    for (int counter = 0; counter < 100; counter:\;)
    {
        int n = number.Next(0,1000);
        min = Math.Min(min, n);
        max = Math.Max(max, n);
    }
    Console.WriteLine(min);
    Console.WriteLine(max);
