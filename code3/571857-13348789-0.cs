    using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL"].ConnectionString.ToString()))
    {
        using (var cmd = conn.CreateCommand())
        { ... }
    }
