    using (var con = new SqlConnection(connectionString))
    {
        foreach (var line in allLines)
        {
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO [YourTable] ([YourColumn]) VALUES (:val)";
                var param = cmd.CreateParameter();
                param.ParameterName = ":val";
                param.Value = line;
                cmd.ExecuteNonQuery();
            }
        }
    }
