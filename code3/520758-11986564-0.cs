      using (var myConnection = new SqlConnection(connectionString))
      using (var myCommand = new SqlCommand(insertSql, myConnection))
      {
          myConnection.Open();
          ...
          myCommand.ExecuteNonQuery();
      }
