    private DataTable GetTableData()
    {
      string sql = "SELECT Id, FisrtName, LastName, Desc FROM MySqlTable";
      using (SqlConnection myConnection = new SqlConnection(connectionString))
      {
        using (SqlCommand myCommand = new SqlCommand(sql, myConnection))
        {
          myConnection.Open();
          using (SqlDataReader myReader = myCommand.ExecuteReader())
          {
            DataTable myTable = new DataTable();
            myTable.Load(myReader);
            myConnection.Close();
            return myTable;
          }
        }
      }
    }
