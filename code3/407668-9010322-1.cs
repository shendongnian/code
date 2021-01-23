    public static char AskForGender()
    {
        while (true)
        {
            Console.Write("Enter gender (m/w): ");
            string inValue = Console.ReadLine(); 
            // check that the user inputs a character
            if (!string.IsNullOrEmpty(inValue) && (inValue[0] == 'm' || inValue[0] == 'w'))
                return inValue[0]; 
        }
    }
