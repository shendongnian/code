    Console.WriteLine("Please enter a word below:");
    Console.WriteLine("");
    string inputString = Console.ReadLine();    // try to use meaningful variable names
    
    // shorthand for the if ... else block:
    // type variableName = (true/false condition) ? "is true" : "is false";
    char firstChar = inputString[0] >= 97 ? (char)(inputString[0] - 32) : (char)(inputString[0] + 32);
  
    Console.WriteLine("");
    Console.Write(firstChar);
    for (int i = 1; i < inputString.Length; i++)    // skip firstChar
    {
        Console.Write(str[i]);
    }
