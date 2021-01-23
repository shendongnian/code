    class Program
    {
        static ManualResetEvent signal = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            Thread t = new Thread(_ => { Thread.Sleep(1500); Console.WriteLine("Signaling back"); signal.Set(); });
            t.Start();
            signal.WaitOne();
            Console.WriteLine("Signal received, done!");
            Console.Read();
        }
    }
