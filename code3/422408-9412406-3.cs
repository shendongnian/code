    public static DataTable GetTable(string tableName, string connectionString)
    {
      using (SqlConnection myConnection = new SqlConnection(connectionString))
      {
        using (SqlCommand myCommand = new SqlCommand(tableName))
        {
          myCommand.Connection = myConnection;
          myCommand.CommandType = CommandType.TableDirect;
          using (SqlDataReader reader = myCommand.ExecuteReader())
          {
            DataTable table = new DataTable();
            table.Load(reader);
            return table;
          }
        }
      }
    }
