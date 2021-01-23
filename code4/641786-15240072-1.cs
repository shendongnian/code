    private void CopyColumns(DataTable source, DataTable dest, params string[] columns)
    {
     foreach (DataRow sourcerow in source.Rows)
     {
       DataRow destRow = dest.NewRow();
        foreach(string colname in columns)
        {
          destRow[colname] = sourcerow[colname];
        }
       dest.Rows.Add(destRow);
      }
    }
    CopyColumns(source, destiny, "Column1", "column2");
