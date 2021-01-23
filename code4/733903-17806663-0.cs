    /// <summary>
    /// returns lengths of all the numeric sequences encountered in the string
    /// </summary>        
    static IEnumerable<int> Lengths(string str)
    {
        var count = 0;
        for (var i = 0; i < str.Length; i++)
        {
            if (Char.IsNumber(str[i]))
            {
                count++;
            }
            if ((!Char.IsNumber(str[i]) || i == str.Length - 1) && count > 0)
            {
                yield return count;                
                count = 0;                    
            }
        }
        if (count > 0)
        {
            yield return count;
        }
    }
