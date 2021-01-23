    using (var con = new SqlConnection(connectionString))
    {
        foreach (var line in allLines)
        {
            using (var cmd = con.CreateCommand())
            {
                var dataAdapter = new SqlDataAdapter();
                cmd.CommandText = "INSERT TO YourTable (YourColumn) VALUES (:val)";
                var param = cmd.CreateParameter();
                param.ParameterName = ":val";
                param.Value = line;
                cmd.ExecuteNonQuery();
            }
        }
    }
