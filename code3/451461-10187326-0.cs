    string inputString;
    
    string pattern = @"^\p{Nd}+$";
    Regex re = new Regex(pattern);
    
    inputString = Console.ReadLine();
    
    while (!re.Match(inputString).Success) {
        Console.WriteLine("Please stick to numerals");
        inputString = Console.ReadLine();
    }
    Console.WriteLine(inputString);
