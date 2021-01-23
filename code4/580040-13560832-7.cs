        static void Main(string[] args)
        {
            long i = 0;
            int runs = 10*1000*1000;
            Task[] t = new Task[Environment.ProcessorCount];
            Stopwatch stp = Stopwatch.StartNew();
            for (int k = 0; k < t.Length; k++)
            {
                t[k] = Task.Run(() =>
                {
                    for (int j = 0; j < runs; j++ )
                    {
                        i++;
                    }
                });
            }
            Task.WaitAll(t);
            stp.Stop();
            Console.WriteLine("i = {0}   should be = {1}  ms={2}", i, runs * t.Length, stp.ElapsedMilliseconds);
            Console.ReadLine();
        }
