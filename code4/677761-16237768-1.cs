    List<string> result = new List<string>();
    foreach (DataTable item in dataSet.Tables)
    {
        result.AddRange(item.Columns.Cast<DataColumn>().Select(i => i.ColumnName).ToList());
    }
