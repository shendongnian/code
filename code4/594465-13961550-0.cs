    public int AlphaNumericCount(string s)
    {
        int count = 0;
        
        for(int i = 0; i < s.Length; i++)
        {
           if(Char.IsLetterOrDigit(s[i])) 
              count++;
        }
    
        return count;
    }
