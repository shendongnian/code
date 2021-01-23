        private static void UserEventHandler()
        {
            while (true)
            {
                inf = Console.ReadKey(true);
                if (inf.Key != ConsoleKey.Enter)
                    input.Append(inf.KeyChar);
                else
                {
                    input = new StringBuilder();
                    userInput = "";
                }
                userInput = input.ToString();
            }
        }
