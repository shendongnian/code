    string permutations = string.Empty;
    Console.WriteLine("Enter Morse Code: \n");
    permutations = Console.ReadLine(); // read the console
    bool isValid = Regex.IsMatch(permutations, @"^[-. ]+$"); // true if it only contains whitespaces, dots or dashes
    if (isValid) //if input is proper
    {
        permutations = permutations.Replace(" ",""); //remove whitespace from string
    }
    else //input is not proper
    {
        Console.WriteLine("Error: Only dot, dashes and spaces are allowed. \n"); //display error
    }
