    NpgsqlConnection conn = new NpgsqlConnection(connString); 
    conn.Open(); 
    if (conn.State == System.Data.ConnectionState.Open) 
           Console.WriteLine("Success open postgreSQL connection."); 
    conn.Close(); 
