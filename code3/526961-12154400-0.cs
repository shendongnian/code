    using (SqlCommand command = server.ConnectionContext.SqlConnectionObject.CreateCommand())
    {
        // Set other properties for "command", like StatementText, etc.
        command.StatementCompleted += (s, e) => {
             Console.WriteLine("{0} row(s) affected.", e.RecordCount);
        };
        command.ExecuteNonQuery();
    }
