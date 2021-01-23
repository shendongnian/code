    char[] myCharacterArray = myString.Where(c => r.IsMatch(c.ToString())).ToArray();
    foreach (char c in myCharacterArray)
    {
        Console.WriteLine(c);
    }
