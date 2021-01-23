    void Main()
    {
        int iterations = 1000000;
        decimal d = 12.0m;
        var text = "";
        
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
        {
            // 1. how I'd have done it
            text = d.ToString();
        }
        sw.Stop();
        sw.ElapsedMilliseconds.Dump("ToString()");
        
        sw = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
        {
            // 2. how I saw someone do it today
            text = String.Format("{0}", d);
        }
        sw.Stop();
        sw.ElapsedMilliseconds.Dump("Format");
    }
