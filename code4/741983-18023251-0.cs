    public const string allowed = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890.,";
    
    public int RetrieveIndex(string input, int startIndex)
    {
        for (var x = startIndex; x < input.length; x++)
        {
            if (allowed.IndexOf(input[x])==-1)
            {
                return x;
            }
         }
    
        return -1;
    }
