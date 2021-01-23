    public async Task<string> QueryGetNameAsync(int id)
    {
      using (var dbConn = new SqlConnection("..."))
      using (var command = new SqlCommand("getName", dbConn))
      {
        try
        {
          command.CommandType = CommandType.StoredProcedure;
          command.Parameters.AddWithValue("@id", id);
          await dbConn.OpenAsync();
          var result = await command.ExecuteScalarAsync();
          dbConn.Close();
          var name = result as string;          
          return name;
        }
        catch (Exception ex)
        {
          // Handle exception here.
        }
      }
    }
