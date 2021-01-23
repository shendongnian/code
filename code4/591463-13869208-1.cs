    using (var conn = new SqlConnection(ConnectionString))
    using (var cmd = conn.CreateCOmmand())
    {
        // no, you are not opening a real connection here, you are just drawing one from the pool
        conn.Open();
        cmd.CommandText = "SELECT ....";
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                // ...
            }
        }
    } // No, you are not closing the connection here, you are simply returning it to the pool
