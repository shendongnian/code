    Random number = new Random();
    int min = int.MaxValue,
        max = int.MinValue;
        
    for (int counter = 0; counter < 100; counter++)
    {
        int n = number.Next(0, 1000);
        Console.WriteLine(n);
        
        if (n < min)
            min = n;
        if (n > max)
            max = n;
    }
    int range = min - max + 1;
    Console.WriteLine("Min = {0}, Max = {1}, Range = {2}", min, max, range);
