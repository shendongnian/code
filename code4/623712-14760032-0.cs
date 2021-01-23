    using (IDbCommand command = myConn.CreateCommand())
    {
        command.CommandText = "insert into foo (value1, value2, value3) values (@v1, @v2, @v3)";
        IDbDataParameter param1 = command.CreateParameter() { ParameterName = "@v1" };
        // param2, param3
        foreach (string[] row in records)
        {
            param1.Value = row[0];
            // param2, param3
            command.ExecuteNonQuery();
        }
    }
    
