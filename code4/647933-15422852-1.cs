    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Thread started.");
            ((Action)Blah).DoLater(10000);
            Console.WriteLine("Press [Escape] to close.");
            while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;
        }
        private static void Blah()
        {
            Console.WriteLine("Blah!");
        }
    }
