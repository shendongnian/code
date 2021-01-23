            int[,] slotBoard = new int[7,7]; 
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\t\t\t\t 1 2 3 4 5 6 7\n");
            Console.ForegroundColor = ConsoleColor.White;
            string tabbing = "\t\t\t\t ";
            for (int r = 0; r < 7; r++)
            {
                System.Threading.Thread.Sleep(100);
                Console.Write(tabbing);
                for (int c = 0; c < 7; c++)
                {
                    Console.Write(0);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n\n\t\t   Where would you like to place your disc? ");
            Console.ForegroundColor = ConsoleColor.White;
            again:
            switch (Console.ReadKey(true).KeyChar.ToString())
            {
                case "1":
                    Console.Write("1");
                    if (slotBoard[0, 0] < 7) slotBoard[0, 0]++;
                    Console.SetCursorPosition(33, 11 - slotBoard[0, 0]);
                    Console.Write("1");
                    Console.SetCursorPosition(60, 13);
                    goto again;
                case "2":
                    Console.Write("2");
                    if (slotBoard[1, 0] < 7) slotBoard[1, 0]++;
                    Console.SetCursorPosition(35, 11 - slotBoard[1, 0]);
                    Console.Write("1");
                    Console.SetCursorPosition(60, 13);
                    goto again;
                case "3":
                    Console.Write("3");
                     if (slotBoard[2, 0] < 7) slotBoard[2, 0]++;
                    Console.SetCursorPosition(37, 11 - slotBoard[2, 0]);
                    Console.Write("1");
                    Console.SetCursorPosition(60, 13);
                    goto again;
                case "4":
                    Console.Write("4");
                     if (slotBoard[3, 0] < 7) slotBoard[3, 0]++;
                    Console.SetCursorPosition(39, 11 - slotBoard[3, 0]);
                    Console.Write("1");
                    Console.SetCursorPosition(60, 13);
                    goto again;
                case "5":
                    Console.Write("5");
                    if (slotBoard[4, 0] < 7) slotBoard[4, 0]++;
                    Console.SetCursorPosition(41, 11 - slotBoard[4, 0]);
                    Console.Write("1");
                    Console.SetCursorPosition(60, 13);
                    goto again;
                case "6":
                    Console.Write("6");
                    if (slotBoard[5, 0] < 7) slotBoard[5, 0]++;
                    Console.SetCursorPosition(43, 11 - slotBoard[5, 0]);
                    Console.Write("1");
                    Console.SetCursorPosition(60, 13);
                    goto again;
                case "7":
                    Console.Write("7");
                    if (slotBoard[6, 0] < 7) slotBoard[6, 0]++;
                    Console.SetCursorPosition(45, 11 - slotBoard[6, 0]);
                    Console.Write("1");
                    Console.SetCursorPosition(60, 13);
                    goto again;
                default:
                    goto again;
            }
