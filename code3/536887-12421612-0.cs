    using System.Threading;
    using System;
    class ThreadTest
    {
        //Index i is declared as static so that both the threads have only one copy
        static int i;
    
        //The lock object
        static readonly object locker = new object();
    
        static void Main(string[] args)
        {
            Thread t = new Thread(WriteY);
    
            i = 0;
    
            //Start thread Y
            t.Start();
            lock (locker)
            {
                // Print X on the main thread
                for (; i < 100; i++)
                {
                    if (i % 10 == 0)
                    {
                        Monitor.PulseAll(locker); // move any "waiting" threads to the "ready" queue
                        Monitor.Wait(locker); // relinquish the lock, and wait for a pulse
                        Console.WriteLine("The X thread");
                    }
                    Console.Write(i + ":X ");
                }
                Monitor.PulseAll(locker);
            }
            Console.ReadKey(true);
        }
    
        static void WriteY()
        {
            lock (locker)
            {
                for (; i < 100; i++)
                {
                    if (i % 10 == 0)
                    {
                        Monitor.PulseAll(locker); // move any "waiting" threads to the "ready" queue
                        Monitor.Wait(locker); // relinquish the lock, and wait for a pulse
                        Console.WriteLine("The Y thread");
                    }
                    Console.Write(i + ":Y ");
                }
                Monitor.PulseAll(locker); // move any "waiting" threads to the "ready" queue
            }
        }
    }
