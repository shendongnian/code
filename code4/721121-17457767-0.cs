    public string RemoveNonUnicodeLetters(string input)
    {
        StringBuilder sb = new StringBuilder();
        foreach(char c in input)
        {
            if(Char.IsLetter(c))
               sb.Append(c);
        }
     
        return sb.ToString();
    }
