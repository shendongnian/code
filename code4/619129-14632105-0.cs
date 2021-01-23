    using System;
    using System.Threading;
    
    class Program {
        static void Main(string[] args) {
            var sync = new ManualResetEvent(false);
            ThreadPool.QueueUserWorkItem((_) => {
                Console.WriteLine("Running");
                Thread.CurrentThread.IsBackground = false;
                sync.Set();
                Thread.Sleep(5000);
                Console.WriteLine("Done, should exit now");
                Thread.Sleep(250);
            });
            sync.WaitOne();  // Ensures IsBackground is set
        }
    }
