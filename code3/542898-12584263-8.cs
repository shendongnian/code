    static void Main(string[] args)
    {
        var lines = new List<string> 
        { 
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            ...
        };
        Enumerable.Range(0, 10).AsParallel().WithDegreeOfParallelism(3).ForAll(i =>
        {
            Console.WriteLine("{0} : {1}", i, lines[i]);
            ////Thread.Sleep(5000);
        }
  
        Console.ReadLine();
    }
