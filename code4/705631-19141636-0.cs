    using (SqlConnection connection = new SqlConnection(connectionString))
    {
       try
       {
          connection.Open();
          using (SqlTransaction trans = connection.BeginTransaction())
          {
              using (SqlCommand command = new SqlCommand("", connection,trans))
              {
                 command.CommandType = System.Data.CommandType.Text;
                 foreach (var commandString in sqlCommandList)
                 {
                    command.CommandText = commandString;
                    command.ExecuteNonQuery();
                 }
              }
              trans.Commit();
           }        
        }
        catch (Exception ex) //error occurred
       {
           //Handel error
       }
    }
