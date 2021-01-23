    var nw = ConfigurationManager.ConnectionStrings["CONNECTION_STRING"];
    int count = 0;
    using (var connection = new SqlConnection())
    {
    connection.ConnectionString = nw.ConnectionString;
    var cmd = connection.CreateCommand();
    cmd.CommandType = CommandType.Text;
    cmd.CommandText = "update Players set...."
    connection.Open();
    count = cmd.ExecuteNonQuery();
    }
