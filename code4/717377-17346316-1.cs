    public static bool IsValid(string source, string test) 
    {
       return test != null  
              && source != null 
              && test.Length == source.Length 
              && test.Where((x,i) => source[i] != x).Skip(2).Any()
    }
