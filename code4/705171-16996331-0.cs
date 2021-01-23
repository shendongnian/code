    public static long[] GetBTreeChildren(long? parentMask)
    {            
        var branches = new List<long>();
        if (parentMask == null) return branches.ToArray();
        for(int i = 0; i < 63; ++i)
        {
            if( (parentMask & (1L << i)) != 0)
                branches.Add(1L << i);
        }            
        return branches.ToArray();
    }
