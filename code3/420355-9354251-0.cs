    public static bool getBoolInputValue()
    {
        bool value;
        bool valid;
        do
        {
            Console.WriteLine("Enter yes or no: ");
            var inputString = Console.ReadLine();
            if (String.IsNullOrEmpty(inputString))
            {
                continue;
            }
            if ( string.Equals(inputString, "yes")
            {
               value = true;
               valid = true;
            }
            else if ( string.Equals(inputString, "no")
            {
               value = false;
               valid = true;
            }
        } while (!valid);
        return value;
    }
