        static int GetNumberFromUser(string order)
        {
            string userText = String.Empty;
            int result;
            Console.Write("Please enter {0} number: ", order);
            userText = Console.ReadLine();
            while (!int.TryParse(userText, out result))
            {
                Console.WriteLine("FAILED");
                Console.Write("Please enter {0} number: ", order);
                userText = Console.ReadLine();
            }
            return result;
        }
