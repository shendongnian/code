    List<string> listtoRemove = new List<string> { "CLM6", "CLM7", "CLM20" };
    for (int i = dt.Columns.Count - 1; i >= 0; i--)
    {
       DataColumn dc = dt.Columns[i];
       if (listtoRemove.Contains(dc.ColumnName.ToUpper()))
       {
           dt.Columns.Remove(dc);
       }
    }
