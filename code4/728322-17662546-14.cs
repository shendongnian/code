    static void Main(string[] args) {
        IList objects = new List<Obj>();
        for(int i = 0; i < 8000; i++)
            objects.Add(new Obj());
        var properties = typeof(Obj).GetProperties();
    
    
        var sw1 = System.Diagnostics.Stopwatch.StartNew();
        InitializeData1(objects, properties, new List<Dictionary<string, object>>());
        sw1.Stop();
        Console.WriteLine("Reflection PropertyInfo.GetValue: " + sw1.ElapsedTicks.ToString());
    
        // cold cache testing
        var sw2_coldCache = System.Diagnostics.Stopwatch.StartNew();
        InitializeData2<Obj>(objects, properties, new List<Dictionary<string, object>>(), new Dictionary<string, Func<Obj, object>>());
        sw2_coldCache.Stop();
        Console.WriteLine("Cached Getters (Cold cache): " + sw2_coldCache.ElapsedTicks.ToString());
    
        // cache initialization
        InitializeData2<Obj>(new List<Obj> { new Obj() }, properties, new List<Dictionary<string, object>>(), gettersCache);
        // hot cache testing
        var sw2_hotCache = System.Diagnostics.Stopwatch.StartNew();
        InitializeData2<Obj>(objects, properties, new List<Dictionary<string, object>>(), gettersCache);
        sw2_hotCache.Stop();
        Console.WriteLine("Cached Getters (Hot cache): " + sw2_hotCache.ElapsedTicks.ToString());
    
        var sw3 = System.Diagnostics.Stopwatch.StartNew();
        InitializeData3(objects, properties, new List<Dictionary<string, object>>());
        sw3.Stop();
        Console.WriteLine("returnProps special method: " + sw3.ElapsedTicks.ToString());
        var sw4 = System.Diagnostics.Stopwatch.StartNew();
        InitializeData2_NonGeneric(objects, properties, new List<Dictionary<string, object>>());
        sw4.Stop();
        Console.WriteLine("Cached Getters (runtime types resolving): " + sw4.ElapsedTicks.ToString());
    }
