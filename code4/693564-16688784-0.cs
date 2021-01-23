    class Program
    {
        static void Main(string[] args)
        {
            ManualResetEvent handle = new ManualResetEvent(false);
            Thread thread = new Thread(o =>
                {
                    WorkBeforeEvent();
                    handle.Set();
                    WorkAfterEvent();
                    Console.WriteLine("Child Thread finished");
                });
            thread.Start();
            Console.WriteLine("Main Thread waiting for event from child");
            handle.WaitOne();
            Console.WriteLine("Main Thread notified of event from child");
            Console.ReadLine();
        }
        public static void WorkBeforeEvent()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Before Event");
        }
        public static void WorkAfterEvent()
        {
            Thread.Sleep(1000);
            Console.WriteLine("After Event");
        }
    }
