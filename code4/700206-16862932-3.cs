    using (OleDbConnection conn = /* Create new instance using your favorite method */)
    {
        conn.Open();
        using (OleDbCommand command = /* Create new instance using your favorite method */)
        {
            using (OleDbDataReader dr = cmd.ExecuteReader())
            { 
                while (dr.Read()) 
                { 
                    //read here 
                } 
           } 
        }
        conn.Close(); // Optional
    }
