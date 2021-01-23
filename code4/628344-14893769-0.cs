    using (var conn = SomeUtilityClass.GetOpenConnection())
    using (var cmd = conn.CreateCommand()) 
    {
        cmd.CommandText = sqlquery;
        int rowCount = dbCommand.ExecuteNonQuery();
        return 1;
    }
