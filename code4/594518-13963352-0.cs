    Dictionary<String, Double> valuesDictionary =
        row.Table.Columns.Cast<DataColumn>()
                         .Where(col =>
                         {
                             double d;
                             return double.TryParse(row.Field<String>(col.ColumnName), out d);
                         })
                         .ToDictionary(
                             col => col.ColumnName,
                             col => double.Parse(row.Field<String>(col.ColumnName)));
