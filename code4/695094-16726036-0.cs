    public string[] RemoveSpecialCharacters(string input)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in input)
        {
            if (Char.IsLetter(c) || Char.IsWhiteSpace(c) || c == '\'')
               sb.Append(c);
        }
    
        return sb.ToString().Split(' ');
    }
