    class Program
    {
        static void Main(string[] args)
        {
            int spaces = 0;
            char key;
            while ((key = Console.ReadKey().KeyChar) != '.') {
                if (key == ' ')
                    spaces++;
            }
            Console.WriteLine();
            Console.WriteLine("Number of spaces: {0}", spaces);
            Console.ReadKey();
        }
    }
