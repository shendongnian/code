    static void Main(string[] args)
    {
        byte[] serialized = new byte[16 * 10000000];
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < 10000000; ++i)
        {
            decimal d = i;
            // Serialize
            using (var ms = new MemoryStream(serialized))
            {
                ms.Position = (i * 16);
                using (var bw = new BinaryWriter(ms))
                {
                    bw.Write(d);
                }
            }
        }
        var ser = sw.Elapsed.TotalSeconds;
        sw = Stopwatch.StartNew();
        decimal total = 0;
        for (int i = 0; i < 10000000; ++i)
        {
            // Deserialize
            using (var ms = new MemoryStream(serialized))
            {
                ms.Position = (i * 16);
                using (var br = new BinaryReader(ms))
                {
                    total += br.ReadDecimal();
                }
            }
        }
        var dser = sw.Elapsed.TotalSeconds;
        Console.WriteLine("Time: {0:0.00}s serialization, {1:0.00}s deserialization", ser, dser);
        Console.ReadLine();
    }
