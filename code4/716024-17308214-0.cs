    class A
    {
    }
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool F<T>(T a, T b) where T : class
    {
        return a.GetHashCode() == b.GetHashCode();
    }
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool F2(A a, A b)
    {
        return a.GetHashCode() == b.GetHashCode();
    }
    
    static int Main(string[] args)
    {
        const int Runs = 100 * 1000 * 1000;
        var a = new A();
        bool lret = F<A>(a, a);
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < Runs; i++)
        {
            F<A>(a, a);
        }
        sw.Stop();
        Console.WriteLine("Generic: {0:F2}s", sw.Elapsed.TotalSeconds);
    
        lret = F2(a, a);
        sw = Stopwatch.StartNew();
        for (int i = 0; i < Runs; i++)
        {
            F2(a, a);
        }
        sw.Stop();
        Console.WriteLine("Non Generic: {0:F2}s", sw.Elapsed.TotalSeconds);
    
        return lret ? 1 : 0;
    }
