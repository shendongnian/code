    using System;
    using System.Threading;
    static class Program
    {
        private static decimal shared ;
        static void Main()
        {
            Random random = new Random(12345);
            decimal[] values = new decimal[20];
            Console.WriteLine("Values:");
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = (decimal)random.NextDouble();
                Console.WriteLine(values[i]);
            }
            Console.WriteLine();
            object allAtOnce = new object();
            int waiting = 10;
            shared = values[0];
            int correct = 0, fail = 0;
            for(int i = 0 ; i < 10 ; i++)
            {
                Thread thread = new Thread(() =>
                {
                    lock(allAtOnce)
                    {
                        if (Interlocked.Decrement(ref waiting) == 0)
                        {
                            Monitor.PulseAll(allAtOnce);
                        } else
                        {
                            Monitor.Wait(allAtOnce);
                        }
                    }
                    for(int j = 0 ; j < 1000 ; j++)
                    {
                        for(int k = 0 ; k < values.Length ; k++)
                        {
                            Thread.MemoryBarrier();
                            var tmp = shared;
                            if(Array.IndexOf(values, tmp) < 0)
                            {
                                Console.WriteLine("Invalid value detected: " + tmp);
                                Interlocked.Increment(ref fail);
                            } else
                            {
                                Interlocked.Increment(ref correct);
                            }
                            shared = values[k];
                        }
                    }
                    if (Interlocked.Increment(ref waiting) == 10)
                    {
                        Console.WriteLine("{0} correct, {1} fails",
                            Interlocked.CompareExchange(ref correct, 0, 0),
                            Interlocked.CompareExchange(ref fail, 0, 0));
                        Console.WriteLine("All done; press any key");
                        Console.ReadKey();
                    }
                });
                thread.IsBackground = false;
                thread.Start();
            }
        }
    }
