    public static int Process(string input)
    {
        input = input.Trim();                                          // Removes all leading and trailing white-space characters 
        char lastChar = input[input.Length - 1];                       // Gets the last character of the input
        if (char.IsDigit(lastChar))                                    // If the last character is a digit
            return int.Parse(input, CultureInfo.InvariantCulture);     // Returns the converted input, using an independent culture (easy ;)
        int number = int.Parse(input.Substring(0, input.Length - 1),   // Gets the number represented by the input (except the last character)
                               CultureInfo.InvariantCulture);          // Using an independent culture
        switch (lastChar)
        {
            case 's':
                return number;
            case 'm':
                return number * 60;
            case 'h':
                return number * 60 * 60;
            case 'd':
                return number * 24 * 60 * 60;
            default:
                throw new ArgumentException("Invalid argument format.");
        }
    }
