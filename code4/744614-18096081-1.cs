    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    
    namespace AsyncTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                // First Counter (Thread)
                Invoke(new ThreadStart(Do));
                Thread.Sleep(10000);
    
                // Second Counter (Thread)
                Invoke(new ThreadStart(Do));
                Console.ReadLine();
            }
    
            public static void Do()
            {
                for (int i = 0; i < 10000000; i++)
                {
                    Console.WriteLine("Test: " + i.ToString());
                    Thread.Sleep(100);
                }
            }
    
            public static void Invoke(ThreadStart ThreadStart)
            {
                Thread cCurrentThread = null;
                try
                {
                    cCurrentThread = new Thread(ThreadStart);
                    cCurrentThread.Start();
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
