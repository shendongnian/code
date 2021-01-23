    using (SqlConnection connection = dac.GetConnection())
    {
      using (SqlCommand command = new SqlCommand("myProc", connection))
      {
        command.CommandType = CommandType.StoredProcedure;
        try
        {
          connection.Open();           
          //add params, run query
    
        }
        catch (Exception ex)
        {
          //handle/log errror
        }
        finally
        {
          if (connection.State == ConnectionState.Open)
            connection.Close();
        }
      }
    }
