    public static void Main(string[] args)
    {
        DisplayMenu();
        while(true)
        {
            int menuChoice;
            string userInput = Console.Readline();
            if(Int32.TryParse(userInput, out menuChoice))
            {
                if(menuChoice >= 1 && menuChoice <= 5)
                   RunCommand(menuChoice);
                else
                   Console.WriteLine("Enter a number between 1-5");
            }
            else
                Console.WriteLine("A number between 1-5 is required!");
    
        }
    
    }
