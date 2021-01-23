    public static void Main(string[] args)
    {
        string input = "This is 2 much junk, 123,";
        var match = Regex.Match(input, @"(\d*),$");  // Ends with at least one digit 
                                                     // followed by comma, 
                                                     // grab the digits.
        if(match.Success)
            Console.WriteLine(match.Groups[1]);  // Prints '123'
    }
