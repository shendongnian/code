    using (DbConnection conn = factory.CreateConnection())
    {
       conn.ConnectionString = connString;
       DbCommand cmd = conn.CreateCommand();
       cmd.CommandText = "...";
       conn.Open();
       DbDataReader reader = cmd.ExecuteReader();
       while (reader.Read())
       { ...
       }
    }
