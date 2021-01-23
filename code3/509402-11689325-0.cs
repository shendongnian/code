    string stringOne = "ThE    OlYmpics 2012!";
    string stringTwo = "THe\r\n    OlympiCs 2012!";
    string fixedStringOne = Regex.Replace(stringOne, @"\s", "");
    string fixedStringTwo = Regex.Replace(stringTwo, @"\s", "");
    bool isEqual = String.Equals(
        fixedStringOne,
        fixedStringTwo,
        StringComparison.OrdinalIgnoreCase);
    Console.WriteLine(isEqual);
    Console.Read();
