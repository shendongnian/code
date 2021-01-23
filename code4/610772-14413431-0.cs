    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine(args[0]);
            }
            else
            {
                Console.WriteLine("no args");
            }
        }
    }
