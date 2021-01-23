    var keepColNames = new List<String>(){ "clm5" };
    var allColumns   = tbl.Columns.Cast<DataColumn>();
    var allColNames  = allColumns.Select(c => c.ColumnName);
    var removeColNames = allColNames.Except(keepColNames);
    var colsToRemove = from r in removeColNames
                       join c in allColumns on r equals c.ColumnName
                       select c;
    while (colsToRemove.Any())
        tbl.Columns.Remove(colsToRemove.First());
