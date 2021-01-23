            Console.Write("\t\t\t+");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("-----------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("+");
            Console.Write("\t\t\t|");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("---MENU----------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("|");
            Console.Write("\t\t\t|");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("------|1|-HELP MENU----------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("|");
            Console.Write("\t\t\t|");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("------|2|-INITIATE CHAT------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("|");
            Console.Write("\t\t\t|");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("------|3|-CONFIGURATION -----");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("|");
            Console.Write("\t\t\t+");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("-----------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("+");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Input >");
            string result = Console.ReadLine();
            switch (result)
            {
                case "1":
                    Console.WriteLine("1");
                    break;
                case "2":
                    Console.WriteLine("2");
                    break;
                default:
                    Console.WriteLine("Invalid");
                    break;
            }
            Console.ReadLine();
