    class Bar
    {
        ~Bar()
        {
            Console.WriteLine("Finalized!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Bar bar = new Bar();
            GC.Collect();
            Thread.Sleep(1000);
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
