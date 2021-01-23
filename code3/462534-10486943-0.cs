    using System;
    using System.Threading;
    
    namespace ConsoleApplication7
    {
        class Program
        {
            static bool keepGoing;
            static void Main(string[] args)
            {
                keepGoing = true;
                Worker worker = new Worker(new KeepGoingDelegate(KeepGoing));
                Thread thread = new Thread(worker.DoWork);
                thread.IsBackground = true;
                thread.Start();
    
                while (thread.ThreadState != ThreadState.Stopped)
                {
                    switch (Console.ReadKey(true).KeyChar)
                    {
                        case 'p':
                            keepGoing = false;
                            break;
                        case 'w':
                            keepGoing = true;
                            break;
                        case 's':
                            worker.Stop();
                            break;
                    }
                    Thread.Sleep(100);
                }
                Console.WriteLine("Done");
                Console.ReadKey();
            }
    
            static bool KeepGoing()
            {
                return keepGoing;
            }
        }
    
        public delegate bool KeepGoingDelegate();
        public class Worker
        {
            bool stop = false;
            KeepGoingDelegate KeepGoingCallback;
            public Worker(KeepGoingDelegate callbackArg)
            {
                KeepGoingCallback = callbackArg;
            }
    
            public void DoWork()
            {
                while (!stop)
                {
                    Console.Write(KeepGoingCallback()?"\rWorking":"\rPaused ");
                    
                    Thread.Sleep(100);
                }
                Console.WriteLine("\nStopped");
            }
    
            public void Stop()
            {
                stop = true;
            }
        }
    }
