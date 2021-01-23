    void Main()
    {
        const int n = 1000000;
        const int r = n / 10;
        var a = Enumerable.Range(0, n);
    
        var t = Stopwatch.StartNew();
    
        Console.WriteLine(a.RotateLeft(r).ToArray().First());
        Console.WriteLine(a.RotateLeft(-r).ToArray().First());
        Console.WriteLine(a.RotateRight(r).ToArray().First());
        Console.WriteLine(a.RotateRight(-r).ToArray().First());
    
        Console.WriteLine(t.ElapsedMilliseconds); // e.g. 236
    }
