    var result =
        dt.Columns
            .Cast<DataColumn>()
            .Select(c =>
                new
                {
                    c.ColumnName,
                    DistinctValuesCount =
                        dt.Rows
                            .Cast<DataRow>()
                            .Select(r => r[c])
                            .Distinct()
                            .Count()
                })
            .OrderByDescending(i => i.DistinctValuesCount)
            .ToArray(); 
