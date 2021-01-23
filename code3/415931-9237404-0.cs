    // 1. Find the indices of all filtered columns:
    var commonColsIdx = dt2Query.AsEnumerable()
                                .Where(dc => targetTable.Columns.Contains(dc.ColumnName))
                                .Select((_,index) => index);
    // 2. In the dataRow query, exclude those items that appear in one of the filtered columns:
    row2.ItemArray.Where((r2,idx) => !commonColsIdx.Contains(idx)))
