    IEnumerable<IGrouping<object, DataRow>> Group(IEnumerable<DataRow> rows, GroupType groupType)
    {
        // switch case would be preferable, but you get the idea.
        if(groupType == GroupType.Minutes) return rows.GroupBy(r => ((object)((DateTime)r[0]).Minute));
        if(groupType == GroupType.Seconds) return rows.GroupBy(r => ((object)((DateTime)r[0]).Second));
        ...
    }
    
    var baseQuery = table.Rows.Cast<DataRow>();
    var grouped = Group(baseQuery, groupType);
    var query = grouped
        .Select(g => new
                     {
                        g.Key, 
                        Sum = g.Sum(r => (int)r[2]),
                        Average = g.Average(r => (int)r[3])
                     });
