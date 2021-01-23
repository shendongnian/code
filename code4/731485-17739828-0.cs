    class database
    {
        // Here you define properties: OK
        SQLiteConnection sqlite_conn;
        SQLiteCommand sqlite_cmd;
        SQLiteDataReader sqlite_datareader;
    
    
        // Then, you do stuff to them: NOT OK
        sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");
    
       //open the connection:
         sqlite_conn.Open();
    
       // create a new SQL command:
         sqlite_cmd = sqlite_conn.CreateCommand();
    
    }
    }
