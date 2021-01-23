        static void Main(string[] args)
        {
            int x = 5;
            Print(x);
            Console.ReadLine();
        }
        static void Print(object x)
        {
            int y = (int)x;
            Console.WriteLine(y);
        }
