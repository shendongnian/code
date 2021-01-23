    using System;    
    using System.Threading;
    class Program
    {
        static void Main()
        {
            ManualResetEvent gate = new ManualResetEvent(false);
            int numberOfThreads = 10, pending = numberOfThreads;
            Thread[] threads = new Thread[numberOfThreads];
            ParameterizedThreadStart work = name =>
            {
                Console.WriteLine("{0} approaches the tape", name);
                if (Interlocked.Decrement(ref pending) == 0)
                {
                    Console.WriteLine("And they're off!");
                    gate.Set();
                }
                else gate.WaitOne();
                Race();
                Console.WriteLine("{0} crosses the line", name);
            };
            for (int i = 0; i < numberOfThreads; i++)
            {
                threads[i] = new Thread(work);
                threads[i].Start(i);
            }
            for (int i = 0; i < numberOfThreads; i++)
            {
                threads[i].Join();
            }
            Console.WriteLine("all done");
    
        }
        static readonly Random rand = new Random();
        static void Race()
        {
            int time;
            lock (rand)
            {
                time = rand.Next(500,1000);
            }
            Thread.Sleep(time);
        }
    
    }
