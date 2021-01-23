    class Program
    {
        public static bool forward = false;
        public static bool stop = false;
        static void Main(string[] args)
        {
            PrintNumbers(0);
            Console.ReadLine();
        }
        private static void PrintNumbers(int i)
        {
            if (i <= 10 && !forward)
            {
                Console.WriteLine(i);
                if (i == 10)
                {
                    forward = true;
                }
                PrintNumbers(i + 1);
            }
            if (i >= 0  && i < 10 && forward && !stop)
            {
                Console.WriteLine(i);
                PrintNumbers(i - 1);
                if (i==0)
                {
                    stop = true;
                }
            }
        }
    }
