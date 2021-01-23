    int lineNum = 0;
    try
    {
        string[] cmdTexts = File.ReadAllLines("script.sql");
        
        using (var oracleConnection = new OracleConnection(_connectionString))
        {
             oracleConnection.Open();
             OracleCommand command = new OracleCommand();
             command.Connection = oracleConnection;
             foreach(string cmd in cmdTexts)
             {
                  lineNum++;
                  if(cmd.Trim().Length > 0)
                  {
                      if(cmd.EndsWith(";"))
                          cmd = cmd.Substring(0, cmd.Length - 1);
                      command.CommandText = cmd;
                      command.ExecuteNonQuery();
                  }
             }
        }
    }
    catch(Exception ex)
    {
        MessageBox.Show("Exception on line: " + lineNum + " message: " + ex.Message);
    }
