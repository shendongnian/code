    using(SQLiteConnection cn = new SQLiteConnection(GetConnectionString()))
    {
         AttachDB(@"C:\SQLite\UserData.sqlite3", "UserData", cn);
         // Do your code here
    } 
    
