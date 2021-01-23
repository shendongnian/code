    public static void Replace_x00D_(DataTable data)
    {
      List<DataColumn> stringColumns = new List<DataColumn>();
      foreach (DataColumn dc in data.Columns)
      {
        if (dc.DataType == typeof(string))
          stringColumns.Add(dc);
      }
      foreach (DataRow rw in data.Rows)
      {
        foreach (DataColumn dc in stringColumns)
          rw.Field<string>(dc).Replace("_x00D_", "");
      }
    }
