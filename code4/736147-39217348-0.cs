    using (IDbConnection phConn = new PhoenixConnection())
    {
        phConn.ConnectionString = cmdLine.ConnectionString;
    
        phConn.Open();
    
        using (IDbCommand cmd = phConn.CreateCommand())
        {
            cmd.CommandText = "SELECT * FROM GARUDATEST";
            using (IDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    for(int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.WriteLine(string.Format("{0}: {1}", reader.GetName(i), reader.GetValue(i)));
                    }
                }
            }
        }                        
    }
