    class Program
    {
        static void Main(string[] args)
        {
            var locker = new Object();
            int count = 0;
            Parallel.For
                (0
                 , 1000
                 , new ParallelOptions { MaxDegreeOfParallelism = 2 }
                 , (i) =>
                       {
                           Interlocked.Increment(ref count);
                           lock (locker)
                           {
                               Console.WriteLine("Number of active threads:" + count);
                               Thread.Sleep(10);
                            }
                            Interlocked.Decrement(ref count);
                        }
                );
        }
    }
