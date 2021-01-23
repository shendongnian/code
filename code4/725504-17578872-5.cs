    public bool ContainsNonLetters(string input)
    {
        foreach(char c in input)
        {
            if(!Char.IsLetterOrDigit(c))
               return true;
        }
    
        return false;    
    }
