    public static IEnumerable<int> GetNumbers()
    {
        for (int i = 0; i < 140; i++)
        {
            Console.WriteLine(
                "                          Enumerating " + 
                i + " at thread " +
                Thread.CurrentThread.ManagedThreadId);
            yield return i;
        }
    }
    static void Main(string[] args)
    {
        Console.ReadLine();
        Parallel.ForEach(GetNumbers(), number =>
        {
            Console.WriteLine("Processing " + number + 
                " at thread " +
                Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1);
        });
    }
