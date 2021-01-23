        static void Main(string[] args)
        {
            int value = 10;
            for (int x = 1; x <= value; ++x)
                Console.Write("{0, 4}", x);
            Console.WriteLine();
            Console.WriteLine("_________________________________________");
            for (int row = 1; row <= value; ++row)
            {
                for (int column = 1; column <= value; ++column)
                {
                    Console.Write("{0, 4}", row * column);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
