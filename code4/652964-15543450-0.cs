    void Main()
    {
        string p = @"d:\temp\file.txt";
        string result;
        
        Stopwatch sw = new Stopwatch();
        sw.Start();
        for(int i = 0; i < 100000; i++)
        {
            result = " " + Path.GetFileName(p) + " ";
        }
        sw.Stop();
        Console.WriteLine("PathGetFileName:" + sw.Elapsed.ToString());
        sw = new Stopwatch();
        sw.Start();
        string file = Path.GetFileName(p);
        for(int i = 0; i < 100000; i++)
        {
            result = " " + file + " ";
        }
        sw.Stop();
        Console.WriteLine("string concat:" + sw.Elapsed.ToString());
    }
