    var result = Enumerable.Empty<DataRow>();
    var linqTable = table.AsEnumerable();
    if (chkbxMarketsSearch.IsChecked)
    {
        results = results.Union(linqTable.Where(row => row.Field<bool>("IsMarkets"));
    }
    if (chkbxBudgetsSearch.IsChecked)
    {
        results = results.Union(linqTable.Where(row => row.Field<bool>("IsBudgets"));
    }
    if (chkbxProgramsSearch.IsChecked)
    {
        results = results.Union(linqTable.Where(row => row.Field<bool>("IsPrograms"));
    }
    // Probably best to call `ToList()` here before doing much more work...
