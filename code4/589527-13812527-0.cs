    public static int CombineHashCodes(params int[] hashCodes)
    {
        if (hashCodes == null)
        {
            throw new ArgumentNullException("hashCodes");
        }
    
        if (hashCodes.Length == 0)
        {
            throw new IndexOutOfRangeException();
        }
    
        if (hashCodes.Length == 1)
        {
            return hashCodes[0];
        }
    
        var result = hashCodes[0];
    
        for (var i = 1; i < hashCodes.Length; i++)
        {
            result = CombineHashCodes(result, hashCodes[i]);
        }
    
        return result;
    }
    
    private static int CombineHashCodes(int h1, int h2)
    {
        return (h1 << 5) + h1 ^ h2;
    
        // another implementation
        //unchecked
        //{
        //    var hash = 17;
    
        //    hash = hash * 23 + h1;
        //    hash = hash * 23 + h2;
    
        //    return hash;
        //}
    }
