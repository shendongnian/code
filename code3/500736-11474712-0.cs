    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(args.Length);
            foreach (string s in args)
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }
    }
