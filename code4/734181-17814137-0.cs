    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace StackoverflowExample
    {
        class Program
        {
            static AutoResetEvent sequenceLock = new AutoResetEvent(false);
            static int value = 1;
            static void Main(string[] args)
            {
                Task t1 = Task.Run(() =>
                {
                    if (value == 1)
                    {
                        sequenceLock.Set(); //lets t2 past the WaitOne()
                        Thread.Sleep(1000);
                        value = 2;
                    }
                });
    
                Task t2 = Task.Run(() =>
                {
                    sequenceLock.WaitOne(); //Waits for t1 to set the flag.
                    value = 3;
                });
    
                Task.WaitAll(t1, t2);
                Console.WriteLine(value);
                Console.ReadLine();
            }
        }
    }
