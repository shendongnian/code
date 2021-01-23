    var strings = "A,B,,C,DE,F,,G,H,,,,I,J,,K,L,MN,OP,Q,R,STU,V,W,X,Y,Z,".Split(',');
    var testers = new Func<string, bool>[] { 
        s => s == String.Empty, 
        s => s.Length == 0, 
        s => String.IsNullOrEmpty(s), 
        s => s == "" ,
    };
    int n = testers.Length;
    var stopwatches = Enumerable.Range(0, testers.Length).Select(_ => new Stopwatch()).ToArray();
    int count = 0;
    for(int i = 0; i < n; ++i) { // iterate testers one by one
        Stopwatch sw = stopwatches[i];
        var tester = testers[i];
        sw.Start();
        for(int j = 0; j < 10000000; ++j) // increase this count for better precision
            count += strings.Count(tester);
        sw.Stop();
    }
    for(int i = 0; i < testers.Length; i++)
        Console.WriteLine(stopwatches[i].ElapsedMilliseconds);
