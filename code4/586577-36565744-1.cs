    static void Main(string[] args)
    {
        List<string> Ids = GetData("First");
        List<string> Ids2 = GetData("tsriF");
        Stopwatch FirstWatch = new Stopwatch();
        FirstWatch.Start();
        foreach (var batch in Ids2.Batch(5000))
        {
            // Console.WriteLine("Batch Ouput:= " + string.Join(",", batch));
        }
        FirstWatch.Stop();
        Console.WriteLine("Done Processing time taken:= "+ FirstWatch.Elapsed.ToString());
        Stopwatch Second = new Stopwatch();
        Second.Start();
        int Length = Ids2.Count;
        int StartIndex = 0;
        int BatchSize = 5000;
        while (Length > 0)
        {
            var SecBatch = Ids2.Batch2(StartIndex, BatchSize);
            // Console.WriteLine("Second Batch Ouput:= " + string.Join(",", SecBatch));
            Length = Length - BatchSize;
            StartIndex += BatchSize;
        }
        Second.Stop();
        Console.WriteLine("Done Processing time taken Second:= " + Second.Elapsed.ToString());
        Console.ReadKey();
    }
    static List<string> GetData(string name)
    {
        List<string> Data = new List<string>();
        for (int i = 0; i < 100000; i++)
        {
            Data.Add(string.Format("{0} {1}", name, i.ToString()));
        }
        return Data;
    }
