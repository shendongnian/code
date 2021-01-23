    using (var conn = new SqlConnection(connectionString))
    {
        using (var comm = conn.CreateCommand())
        {
            conn.Open();
            comm.CommandText = "SOME SQL HERE";
            // command type, parameters, etc.
            comm.ExecuteNonQuery();
        }
    }
