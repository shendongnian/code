    static void Main(string[] args) {         // Test method
        List<Dictionary<string, object>> tod = new List<Dictionary<string, object>>();
        IList objects = new List<Obj>();
        for(int i = 0; i < 7999; i++)
            objects.Add(new Obj());
    
        var sw1 = System.Diagnostics.Stopwatch.StartNew();
        InitializeData1(objects, typeof(Obj).GetProperties(), tod);
        sw1.Stop();
        Console.WriteLine(sw1.ElapsedTicks);
    
    
        var sw2 = System.Diagnostics.Stopwatch.StartNew();
        InitializeData2<Obj>(objects, typeof(Obj).GetProperties(), tod);
        sw2.Stop();
        Console.WriteLine(sw2.ElapsedTicks);
        var sw3 = System.Diagnostics.Stopwatch.StartNew();
        InitializeData3(objects, properties, tod);
        sw3.Stop();
        Console.WriteLine(sw3.ElapsedTicks); //
    }
