    public static void Blah(long i, ref List<long> list)
    {
        if (i % 10000000 == 0) Console.WriteLine("{0:N0}", i);
        if (IsPanDigital(i))
        {
            list.Add(i);
        }
    }
    var list = new List<long>();
    Parallel.For(1023456789, 1033456789, i => Blah(i, ref list));
