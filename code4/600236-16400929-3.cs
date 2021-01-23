    var connectionBuilder = new SqlConnectionStringBuilder();
    connectionBuilder.DataSource = "localhost\\sqlexpress";
    connectionBuilder.IntegratedSecurity = true;
    var now = DateTime.UtcNow;
    using (var connection = new SqlConnection(connectionBuilder.ConnectionString))
    using (var command = new SqlCommand())
    {
        command.Connection = connection;
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = "ShowGivenSmallDateTimeValue";
        command.Parameters.Add(new SqlParameter("@givenSmallDateTime", SqlDbType.SmallDateTime) { Value = now });
        connection.Open();
        var result = (DateTime)command.ExecuteScalar();
        var difference = result - now;
        Console.WriteLine("Due to the smalldatetime roundings we have a difference of " + difference + ".");
    }
