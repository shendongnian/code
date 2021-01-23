    public bool IsNumeric(string input)
    {
        foreach(char c in input)
        {
           if(!char.IsDigit(c))
           {
              return false;
           }
        }
        
        return true;
    }
