    var SqlFile = @"...";
    var Command = new SqlCommand
    {
      CommandType = CommandType.Text,
      Connection = new SqlConnection()
    };
    Command.Connection.Open();
    foreach (var CommandText in File.ReadAllText(SqlFile).Replace("GO", ";").Split(';'))
    {
      Command.CommandText = CommandText;
      Command.ExecuteNonQuery();
    }
    Command.Connection.Close();
