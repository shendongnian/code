    class Program
    {
        static Program()
        {
            Console.WriteLine("line no 1");
            AppDomain.CurrentDomain.ProcessExit += 
                                              (s, a) => Console.WriteLine("line no 3");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("line no 2");
        }
    }
