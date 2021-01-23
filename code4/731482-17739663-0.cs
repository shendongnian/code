    class database
    {
        // We use these three SQLite objects:
        SQLiteConnection sqlite_conn;
        SQLiteCommand sqlite_cmd;
        SQLiteDataReader sqlite_datareader;
    
        public database()
        {
             sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");
             sqlite_conn.Open();
             sqlite_cmd = sqlite_conn.CreateCommand();
         }   
    
    }
