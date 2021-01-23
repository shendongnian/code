    IEnumerable<char> possibleCharacters = "xy";//change to whatever
    int numberOfDigits = 3;
    
    var result = Enumerable.Repeat(possibleCharacters, numberOfDigits)
         .CartesianProduct()
         .Select(chars => new string(chars.ToArray()));
    //display (or do whatever with) the results
    foreach (var item in result)
    {
        Console.WriteLine(item);
    }
