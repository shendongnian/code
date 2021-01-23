    using (SqliteConnection  conn = new SqliteConnection(GlobalVars.connectionString)) 
    {
				conn.Open ();
				SqliteCommand command = new SqliteCommand (conn);
                                 .............
				
    }
