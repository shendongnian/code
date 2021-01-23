    internal class Program
    {
        private static void Main(string[] args)
        {
            // starting your thread A
            Task.Factory.StartNew(ThreadAWork);
            Console.ReadKey();
        }
    
        // Thread A's method
        private static void ThreadAWork()
        {
            Console.WriteLine("Thread:A Started");
            // starting Thread B from Thread A
            Task.Factory.StartNew(ThreadBWork);
            Thread.Sleep(1000);
            Console.WriteLine("Thread:A Stopped");
        }
    
        // Thread B's method
        private static void ThreadBWork()
        {
            Console.WriteLine("Thread:B Started");
            Thread.Sleep(2000);
            Console.WriteLine("Thread:B Stopped");
        }
    }
