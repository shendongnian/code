    using (var connection = new SqlConnection(...))
    {
        connection.Open();
        using (var command = new SqlCommand(
            "INSERT INTO Foo (Name, RegisterDate) VALUES (@Name, @RegisterDate)",
            connection))
        {
            command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar))
                              .Value = name;
            // TODO: Consider whether you really want the *local* date, or some
            // fixed time zone such as UTC
            command.Parameters.Add(new SqlParameter("@RegisterDate", SqlDbType.DateTime))
                              .Value = DateTime.Today;
            command.ExecuteNonQuery();
        }
    }
