    if ( DataFile != null) 
    { 
        using (var db = new SQLite.SQLiteConnection(DataFile.Path, SQLiteOpenFlags.ReadWrite))
        {
            SQLiteCommand cmd = new SQLiteCommand(db); 
            cmd.CommandText = "UPDATE Test SET Value=1000 WHERE Id = 5"; 
            db.Open();
            cmd.ExecuteNonQuery(); 
        }
    } 
