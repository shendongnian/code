    public static Action<long> Blah(List<long> list)
    {
        return i =>
        {
            if (i % 10000000 == 0) Console.WriteLine("{0:N0}", i);
            if (IsPanDigital(i))
            {
                list.Add(i);
            }
        };
    }
    var list = new List<long>();
    Parallel.For(1023456789, 1033456789, Blah(list));
