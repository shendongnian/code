    using (var connection = GetConnection())
    {
        connection.Open();
        using (var command = connection.CreateCommand())
        {
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT into table(x, y) VALUES (@x, @y)";
            command.Parameters.Add(CreateParameter(command, "@x", x, DbType.String));
            command.Parameters.Add(CreateParameter(command, "@y", y, DbType.String));
            command.ExecuteNonQuery();
        }
    }
