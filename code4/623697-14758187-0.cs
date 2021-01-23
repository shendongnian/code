    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo ki = Console.ReadKey();
            while (ki.KeyChar != 'Z')
            {
                Console.WriteLine(ki.KeyChar);
                ki = Console.ReadKey();
            }
        }
    }
