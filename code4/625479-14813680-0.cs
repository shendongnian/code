    private static void CheckCommand()
    {
        string command;
        do
        {
            command = Console.ReadLine();
            switch (command)
            {
                case ("help"):
                    Console.WriteLine("List of useable verbs and nouns");
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }
        while (command != "exit game");
        
    }
