    private static void Main(string[] args)
    {
        ulong x = ulong.Parse(Console.ReadLine());
        bool gt = x > 32uL;        /* Oh look, a ulong. */
        Console.WriteLine(gt);
    }
