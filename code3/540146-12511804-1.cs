    this.connection.Open();
    try
    {
        var parameters = new { Id = 1 };
        return connection.Query(
            "SELECT Data FROM dbo.Data WHERE Id = @Id", parameters)
            .Select(q => q.Data as byte[])
            .Single();
    }
    finally
    {
        this.connection.Close();
    }
