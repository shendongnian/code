    public class Program
    {
        public static void Main(string[] args)
        {
            new Consumer();
            new Provider();
            Console.WriteLine("Exit ...");
            Console.ReadKey();
        }
    }
    public class Consumer
    {
        public Consumer()
        {
            using(Process p = Process.GetCurrentProcess())
            {
                Console.WriteLine("Consumer : {0}", p.ProcessName);
            }
        }
    }
    public class Provider
    {
        public Provider()
        {
            using(Process p = Process.GetCurrentProcess())
            {
                Console.WriteLine("Provider : {0}", p.ProcessName);
            }
        }
    }
