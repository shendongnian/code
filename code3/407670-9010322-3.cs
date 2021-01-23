    public static char AskForGender()
    {
        while (true)
        {
            Console.Write("Enter gender (m/w): ");
            string inValue = Console.ReadLine(); 
            // check that the user inputs a character
            if (!string.IsNullOrEmpty(inValue) && (inValue.ToUpper()[0] == 'M' || inValue.ToUpper()[0] == 'W'))
                return inValue[0]; 
        }
    }
