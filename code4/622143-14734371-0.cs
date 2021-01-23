    static void CreateTableFromReader(string tableName, SqlDataReader reader) {
      List<string> columns = new List<string>();
      string createTable = @"CREATE TABLE {0} ({1})";
      var dt = reader.GetSchemaTable();
      foreach (DataRow dr in dt.Rows) {
        switch (dr["DataTypeName"].ToString().ToLower()) {
          case "varchar":
            columns.Add(String.Format("[{0}] {1}({2})",
              dr["ColumnName"],
              dr["DataTypeName"],
              dr["ColumnSize"]
            ));
            break;
          case "money": //i know this is redundant but being explicit helps clarity sometimes
          case "date":
          case "integer":
          default:
            columns.Add(String.Format("[{0}] {1}",
              dr["ColumnName"],
              dr["DataTypeName"]
            ));
            break;
        }
      }
      using (var cmd = conn_Access.CreateCommand()) {
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = String.Format(createTable, tableName, String.Join(", ", columns));
        cmd.ExecuteNonQuery();
      }
    }
