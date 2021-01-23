    public class database
    {
        // We use these three SQLite objects:
        public SQLiteConnection sqlite_conn;
        public SQLiteCommand sqlite_cmd;
        public SQLiteDataReader sqlite_datareader;
    
        public database()
        {
             sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");
             sqlite_conn.Open();
             sqlite_cmd = sqlite_conn.CreateCommand();
         }   
    
    }
