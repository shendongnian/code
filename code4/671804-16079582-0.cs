    for (int col = dataTable.Columns.Count - 1; col >= 0; col--)
    {
      bool removeColumn = true;
      foreach (DataRow row in dataTable.Rows)
      {
        if (!row.IsNull(col))
        {
          removeColumn = false;
          break;
        }
      }
      if (removeColumn)
        dataTable.Columns.RemoveAt(col);
    }
