    static unsafe void Main(string[] args)
    {
        byte[] serialized = new byte[16 * 10000000];
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < 10000000; ++i)
        {
            decimal d = i;
            fixed (byte* sp = serialized)
            {
                *(decimal*)(sp + i * 16) = d;
            }
        }
        var ser = sw.Elapsed.TotalSeconds;
        sw = Stopwatch.StartNew();
        decimal total = 0;
        for (int i = 0; i < 10000000; ++i)
        {
            // Deserialize
            decimal d;
            fixed (byte* sp = serialized)
            {
                d = *(decimal*)(sp + i * 16);
            }
            total += d;
        }
        var dser = sw.Elapsed.TotalSeconds;
        Console.WriteLine("Time: {0:0.00}s serialization, {1:0.00}s deserialization", ser, dser);
        Console.ReadLine();
    }
