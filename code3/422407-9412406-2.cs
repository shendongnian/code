    using(SqlConnection myConnection = new SqlConnection("your_connection_string"))
    {
      using(SqlCommand myCommand = new SqlCommand("Table_Name"))
      {
         myCommand.Connection = myConnection;
         myCommand.CommandType = CommandType.Table;
         using(SqlDataReader reader = myCommand.ExecuteReader())
         {
            DataTable table = new DataTable();
            table.Load(reader);
            return table;
         }
       }
    
    }
