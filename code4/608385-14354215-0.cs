    public static class DataTableExtentions {
      public static void AddColumn(this DataTable table, string columnName, Type columnType)
      {
        var col = table.Columns.Add();
        col.ColumnName = columnName;
        col.DataType = columnType;
      }
    }
