    Func<int> getFailureCount;
    int[] items = { 0, 1, 2, 3, 4 };
    foreach(int i in items.Where(i => i % 2 == 0, out getFailureCount))
    {
        Console.WriteLine(i);
    }
    Console.WriteLine("Failures = " + getFailureCount());
