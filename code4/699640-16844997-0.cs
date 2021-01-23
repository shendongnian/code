    static string[] strArr = { "123", "456", "789" };
    
    void Main()
    {
        const int iterations = 10000000; // 10 million
        
        // Warm up JITter
        StringJoin();
        LINQSelectMany();
        LINQ();
        
        Stopwatch sw = Stopwatch.StartNew();
        for (int index = 0; index < iterations; index++)
            StringJoin();
        sw.Stop();
        sw.ElapsedMilliseconds.Dump("String.Join");
        
        sw.Restart();
        for (int index = 0; index < iterations; index++)
            LINQSelectMany();
        sw.Stop();
        sw.ElapsedMilliseconds.Dump("LINQ SelectMany");
    
        sw.Restart();
        for (int index = 0; index < iterations; index++)
            LINQ();
        sw.Stop();
        sw.ElapsedMilliseconds.Dump("LINQ");
    }
    
    public static void StringJoin()
    {
        char[] c = string.Join(string.Empty, strArr).ToCharArray();
    }
    
    public static void LINQSelectMany()
    {
        char[] c = strArr.SelectMany(s => s).ToArray();
    }
    
    public static void LINQ()
    {
        var characters = (from s in strArr
                          from c in s
                          select c).ToArray();
    
    }
