    string str = "value=5412304756756756756756792114343986";
    List<char> justDigits = new List<char>();
    foreach(char c in str)
    {
        if (char.IsDigit(c))
            justDigits.Add(c);
    }
    
    string intValues = new string(justDigits.ToArray());
