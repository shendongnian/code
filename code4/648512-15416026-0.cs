        public static void Map()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n" + xCoordinate + ", " + yCoordinate);
            Console.WriteLine("\nTowns are represented by a \"T\". Current location is shown as an \"X\".\n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int y = 5; y >= -4; y--)
            {
                for (int x = -7; x <= 5; x++)
                {
                    Console.Write(yCoordinate == y && xCoordinate == x ? "[X]" : "[ ]");
                }
                Console.WriteLine(" {0}", y);
            }
            Console.Write("-7 -6 -5 -4 -3 -2 -1  0  1  2  3  4  5\n\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
