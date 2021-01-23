    static void Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        int count = 0;
            
        for (uint i = 0; i < 1000000000; ++i)
        {
            // 1st method
            var isMultipleOf16 = i % 16 == 0;
            count += isMultipleOf16 ? 1 : 0;
            // 2nd method
            //count += i % 16 == 0 ? 1 : 0;
        }
        sw.Stop();
        Console.WriteLine(string.Format("Ellapsed {0}", sw.Elapsed));
        Console.ReadKey();
    }
