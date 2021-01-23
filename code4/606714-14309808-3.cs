    public async Task<string> QueryGetNameAsync(int id)
    {
      using (var dbConn = new SqlConnection("..."))
      using (var command = new SqlCommand("getName", dbConn))
      {
        try
        {
          command.CommandType = CommandType.StoredProcedure;
          command.Parameters.AddWithValue("@id", id);
          command.Parameters.Add("@name", SqlDbType.VarChar, 100);
          command.Parameters["@name"].Direction = ParameterDirection.Output;
          await dbConn.OpenAsync();
          await command.ExecuteNonQueryAsync();
          dbConn.Close();
          var name = command.Parameters["@name"].Value as string;          
          return name;
        }
        catch (Exception ex)
        {
          // Handle exception here.
        }
      }
    }
