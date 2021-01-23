    public SearchWithTwoLevelCache(ISearchCore s, ICurrentTimeProvider tp)
    {
        //Initialize the two levels.
        S=s;
        lvl2 = TimeBoundedQueryCache(s.AsQueryDataSource, tp, TimeSpan(24,0,0));
        lvl1 = SizeBoundedQueryCache(lvl2, 10);
    }
