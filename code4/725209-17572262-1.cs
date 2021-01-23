    public static  IEnumerable<long> RangeLong(long start,long count)
    {
        for(long l=start;l<=count;l++)
            yield return l;
    }
