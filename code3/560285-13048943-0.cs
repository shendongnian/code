                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.Clear();
                int size = 20;
                Console.WriteLine();
                for (int row = 3; row <= size/2; row++)
                {
                    for (int col = 0; col <= size + 1; col++)
                    {
                        if (col == 0 || col == size/2 +1)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            Console.Write(" ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write(" ");
                            Console.ResetColor();
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                for (int row = 3; row <= size/2; row++)
                {
                    for (int col = 0; col <= size + 1; col++)
                    {
                        if (col == 0 || col == size / 2 + 1)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            Console.Write(" ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write(" ");
                            Console.ResetColor();
                        }
                    }
                    Console.WriteLine();
                }
                Console.ReadKey();
