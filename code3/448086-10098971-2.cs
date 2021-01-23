    public static IEnumerable<long> getPyramid(long maxValue)
    {
        for(long i = 0; i <= maxValue; i++)
        {
            yield return i;
        }
    
        for(long i = maxValue; i >=0; i--)
        {
            yield return i;
        }
    }
