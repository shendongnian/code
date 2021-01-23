    private enum AggerationType { Year = 1, Month = 2, Day = 3, Hour = 4 }
    private IList<Data> RunQuery(AggerationType groupType, AggerationType checkType)
    {
        // The actual query which does to trick
        var result =
            from d in testList
            group d by new {
                d.Start.Year,
                Month = (int)groupType >= (int)AggerationType.Month ? d.Start.Month : 1,
                Day = (int)groupType >= (int)AggerationType.Day ? d.Start.Day : 1,
                Hour = (int)groupType >= (int)AggerationType.Hour ? d.Start.Hour : 1
            } into g
            // The where clause checks how much data needs to be in the group
            where CheckAggregation(g.Count(), checkType)
            select new Data() { Start = g.Min(m => m.Start), End = g.Max(m => m.End), Value = g.Sum(m => m.Value) };
        return result.ToList();
    }
    private bool CheckAggregation(int groupCount, AggerationType checkType)
    {
        int requiredCount = 1;
        switch(checkType)
        {
            case AggerationType.Year:
                // I use 365 but this depends on the given year
                requiredCount = requiredCount * 365; 
                goto case AggerationType.Month;
            case AggerationType.Month:
                // I use 30 but this depends on the given month and year
                requiredCount = requiredCount * 30; 
                goto case AggerationType.Day;
            case AggerationType.Day:
                requiredCount = requiredCount * 7;
                goto case AggerationType.Hour;
            
