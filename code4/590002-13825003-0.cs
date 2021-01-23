                string[] welcome = new string[4] { "Welcome", "Choose A Option Bellow By Inputing The Number And Clicking Enter.", "1. View C:\\Windows\\ File directory", "2. View Your Own Custom Directory" };
            String userChoice;
            for (int x = 0; x < 4; x++)
            {
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + welcome[x].Length / 2) + "}", welcome[x]);
            }
            var cprompt = "Choice:";
            Console.Write(string.Format("{0," + ((Console.WindowWidth / 2) + (cprompt.Length/2)) + "}", cprompt ));
            Console.ReadLine();
