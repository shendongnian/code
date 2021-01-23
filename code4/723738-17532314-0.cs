    secondTable = firstTable.AsEnumerable()
        .GroupBy(row => new
        {
            Key = row.Field<string>("Key"),
            Country = row.Field<string>("Country"),
        })
        .Select(group => group.First())
        .CopyToDataTable();
