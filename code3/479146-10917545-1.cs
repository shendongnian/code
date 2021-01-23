    static void Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();
        int[] vals = Enumerable.Range(0, Int16.MaxValue).ToArray();
        sw.Start();
        int[] x1 = vals.Where(IsValid).ToArray();
        sw.Stop();
        Console.WriteLine("Sequential Execution {0} milliseconds", sw.ElapsedMilliseconds);
        sw.Restart();
        int[] x2 = vals.AsParallel().Where(IsValid).ToArray();
        sw.Stop();
        Console.WriteLine("Parallel #1 Execution {0} milliseconds", sw.ElapsedMilliseconds);
        sw.Restart();
        int[] x3 = vals.AsParallel().Where(IsValid).ToArray();
        sw.Stop();
        Console.WriteLine("Parallel #2 Execution {0} milliseconds", sw.ElapsedMilliseconds);
        Console.Read();
    }
    static bool IsValid(int input)
    {
        int result=0;
        for(int i =0;i<5000;i++)            
            result = input%2;
        return result == 0;
    }
