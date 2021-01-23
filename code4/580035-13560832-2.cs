        static void Main(string[] args)
        {
            long i = 1;
            long j = 1;
            Task[] t = new Task[4];
            for (int k = 0; k < 4; k++)
            {
                t[k] = Task.Run(() => {
                                while (Interlocked.Read(ref j) < (long)(10*1000*1000))
                                {
                                    i++;
                                    Interlocked.Increment(ref j);
                                }});
            }
            Task.WaitAll(t);
            Console.WriteLine("i = {0}   j = {1}", i, j);
            Console.ReadLine();
        }
