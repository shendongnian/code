    class Program
    {
        static void Main(string[] args)
        {
            var n = 0;
            while (n < 5)
            {
                var line = Console.ReadLine();
                Console.WriteLine("Read line {0}: {1}", n, line);
                n++;
            }
        }
    }
