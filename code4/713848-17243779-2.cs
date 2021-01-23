    var notAllowedColNames = dtReport.Columns.Cast<DataColumn>()
        .Select(c=> c.ColumnName.ToUpperInvariant())
        .Except(dtHeader.AsEnumerable().Select(r => r.Field<String>("Header").ToUpperInvariant()))
        .ToList();
    foreach(var colName in notAllowedColNames) 
         dtReport.Columns.Remove(colName);
