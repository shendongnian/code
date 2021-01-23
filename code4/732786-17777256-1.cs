        static void Main(string[] args)
        {
            int width, height;
            //int tableWidth;
            Console.Write("How wide do we want the multiplication table? ");
            width = Convert.ToInt32(Console.ReadLine());
            Console.Write("How high do we want the multiplication table? ");
            height = Convert.ToInt32(Console.ReadLine());
            Console.Write("    x|");
            for (int x = 1; x <= width; x++)
                Console.Write("{0, 5}", x);
            Console.WriteLine();
            Console.Write("     |");
            for (int x = 1; x <= (width * 5); x++)
                Console.Write("-");
            Console.WriteLine();
            for (int row = 1; row <= height; row++)
            {
                Console.Write("{0, 5}|", row);
                for (int column = 1; column <= height; ++column)
                {
                    Console.Write("{0, 5}", row * column);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
