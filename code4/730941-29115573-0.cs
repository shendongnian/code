    var content =string.Format("BEGIN {0} END;", File.ReadAllText("script.sql"));
    using (var oracleConnection = new OracleConnection(_connectionString))            
    {
      oracleConnection.Open();
      using (var command = new OracleCommand(content) { Connection = oracleConnection })
      {
           command.CommandType = CommandType.Text;
           command.ExecuteNonQuery();
      }
    }
