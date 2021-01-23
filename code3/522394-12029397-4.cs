    var listofChars = new SortedDictionary<char, int>();
    foreach(char c in File.ReadAllText(fileName))
    {
        if (!listofChars.ContainsKey(c))
        {
            listofChars[c] = 1;
        }
        else
        {
            listofChars[c] += 1;
        } 
    }
