    var toBeRemoved = DT1.Columns.Cast<DataColumn>()
                     .Where(c => !allowed.Contains(c.ColumnName))
                     .ToList();
    foreach(DataColumn col in toBeRemoved)
    {
         DT1.Columns.Remove(col);
    }
