    int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            for (int i = 0; i < width; ++i)
            {
                Console.Write("-");
            }
            for (int j = 0; j < height - 2; ++j)
            {
                Console.Write("|");
                for (int i = 0; i < width - 2; ++i)
                {
                    Console.Write(" ");
                }
                Console.Write("|");
            }
            Console.WindowHeight += 1;
            for (int i = 0; i < width; ++i)
            {
                Console.Write("-");
            }
            Console.WindowHeight -= 1;
 
