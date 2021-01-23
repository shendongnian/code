    using (var conn = new SqlConnection(connectionString))
    using (var cmd = new SqlCommand(commandToRun, conn))
    {
        cmd.Parameters.AddRange(new[]
            {
                new SqlParameter("myParam", "myvalue"),
                new SqlParameter("myParam", "myvalue")
            });
    
        conn.Open(); // opened as late as possible
        using (SqlDataReader reader = cd.ExecuteReader())
        {
            while (reader.Read())
            {
                // do stuff.
            }
        }
    } // disposed here.
