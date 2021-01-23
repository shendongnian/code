    var colAGroups = tbl.AsEnumerable()
                    .GroupBy(row => row.Field<String>("ColumnA"))
                    .Select(grp => new
                    {
                        Value = grp.Key,
                        Sum = grp.Sum(row => row.Field<int>("ColumnB"))
                    });
    foreach (var colAGroup in colAGroups)
    {
        Console.WriteLine(String.Format("{0} {1}", colAGroup.Value, colAGroup.Sum));
    }
