    var lst = dt.AsEnumerable()
    .Select(r => r.Table.Columns.Cast<DataColumn>()
            .Select(c => new KeyValuePair<string, object>(c.ColumnName, r[c.Ordinal])
           ).ToDictionary(z => z.Key, z => z.Value)
    ).ToList();
