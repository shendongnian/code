        public static void ColorizeConsoleMessage(string message)
        {
            MatchCollection matches = Regex.Matches(message, "&+([0-9a-f])([^&]+)");
            ConsoleColor def = Console.ForegroundColor;
            foreach (Match match in matches)
            {
                switch (match.Groups[1].Value[0])
                {
                    case '0':
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case '1':
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case '2':
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                    case '3':
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    case '4':
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case '5':
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case '6':
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case '7':
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                string str_to_print = match.Groups[2].Value;
                Console.Write(str_to_print);
            }
            Console.WriteLine();
            Console.ForegroundColor = def;
        }
