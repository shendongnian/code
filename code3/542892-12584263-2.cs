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
        var parallelOptions = new ParallelOptions
            {        
                MaxDegreeOfParallelism = 3
            };
  
        Parallel.For(0, 9, parallelOptions, i =>
        {
            Console.WriteLine("{0} : {1}", i, lines[i]);
            ////Thread.Sleep(5000);
        });
        Console.ReadLine();
    }
