    static void ParalelSimulationNEW()
    {
        DateTime startTime = DateTime.Now;
        int trails = 1000000;
        int numberofpeople = 23;
        int matches = 0;
        Parallel.For(0, trails + 1, _ =>
        {
            Random rnd = new Random();
                
            var taken = new List<int>();
            for(int k = 0; k < numberofpeople; k++)
            {
                var day = rnd.Next(1, 365);
                if(taken.Contains(day))
                {
                    Interlocked.Increment(ref matches);
                    break;
                }
                taken.Add(day);
            }
        });
        Console.WriteLine((Convert.ToDouble(matches) / trails).ToString());
        TimeSpan ts = DateTime.Now.Subtract(startTime);
        Console.WriteLine("Paralel Time Elapsed: {0} Seconds:MilliSeconds", ts.Seconds + ":" + ts.Milliseconds);
    }
