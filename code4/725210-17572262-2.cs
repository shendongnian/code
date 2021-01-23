    public static  IEnumerable<long> RangeLong(long start,long count)
    {
        for(long l=start;l<=start+count;l++)
            yield return l;
    }
