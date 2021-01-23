    public static char AskForGender()
    {
        while (true)
        {
            Console.Write("Enter gender: ");
            string inValue = Console.ReadLine(); 
            // check that the user inputs a character
            if (!string.IsNullOrEmpty(inValue))
                return inValue[0];
        }
    }
