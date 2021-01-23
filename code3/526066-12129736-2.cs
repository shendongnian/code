    int readIntFromConsole()
    {
        while (true)
        {
            string keyboardInput = Console.ReadLine();
            
            int result;
            if (int.TryParse(keyboardInput, out result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Invalid input, try again.");
            }
        }
    }
