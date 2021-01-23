    class Program
    {
        static Program()
        {
            Console.WriteLine("Line 1");
            AppDomain.CurrentDomain.ProcessExit += (sender, args) => Console.WriteLine("Line 3");      
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Line 2");
        }
    }
