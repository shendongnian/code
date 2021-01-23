    var result = dt.Columns
        .Cast<DataColumn>()
        .Select(dc => new {
            Name = dc.ColumnName,
            Values = dt.Rows
                .Cast<DataRow>()
                .Select(row => row[dc])
                .Distinct()
                .Count()})
        .OrderBy(item => item.Values);
