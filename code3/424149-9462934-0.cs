    using System;
    using System.Threading;
    using Timer = System.Timers.Timer;
    
    class Test
    {
        static void Main()
        {
            Timer timer = new Timer(1000);
            timer.Elapsed += ElapsedHandler;
            timer.Enabled = true;
            Thread.Sleep(10000);
            timer.Enabled = false;
        }
        
        static void ElapsedHandler(object sender, EventArgs e)
        {
            int id = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("{0}: Starting to sleep", id);
            Thread.Sleep(5000);
            Console.WriteLine("{0}: Exiting", id);
        }
    }
