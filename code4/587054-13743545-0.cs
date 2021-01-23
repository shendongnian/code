    List<string> result = new List<string>();
    using (SqlConnection connection = new SqlConnection(databaseConnectionString))
    {
      connection.Open();
      using (SqlCommand command = new SqlCommand(query, connection))
      {
        command.CommandType = CommandType.Text;
        using (SqlDataReader reader = command.ExecuteReader())
        {
          while (reader.Read())
          {
            result.Add(reader.GetString(0));
          }
          
          reader.Close();
        }
        command.Cancel();
      }
    }
    
    return result;
