    public bool CheckIfIdExists(string paramValue)
    {
        var result = false;
        using (var conn = new OracleConnection(_connectionString))
        {
          conn.Open();
          using (var cmd = new OracleCommand("SQL query", conn))
          {
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Add("paramName", paramValue);
            using (var rdr = cmd.ExecuteReader())
            {
              result = rdr.HasRows;
            }
          }
        }
        return result;
    }
