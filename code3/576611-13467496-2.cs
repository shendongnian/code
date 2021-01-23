    try
    {
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
    
        using(SqlCommand command = new SqlCommand("inv_check", connection))
        {
          command.CommandType = CommandType.StoredProcedure;
          command.Parameters.Add("@batch_date", SqlDbType.DateTime).Value = DateTime.Now; // or the variable which holds datetime
          connection.Open();
          return command.ExecuteNonQuery();
        }
      }
    }
    catch (SqlException ex)
    {
       Response.Write("SQL Error" + ex.Message.ToString());
    }
