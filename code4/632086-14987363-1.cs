    SQLiteConnection db = new SQLiteConnection("Data Source=test.sqlite;Version=3;");
        SQLiteCommand cmd = db.CreateCommand();
        cmd.CommandType = CommandType.Text;
        query = "SELECT * FROM Table";
        command.CommandText = query;
        db.Open();
    
        SQLiteDataReader reader = cmd.ExecuteReader(); //This is the line that throws
        while (reader.Read())
        {
           //read and do work. (This section has been tested and works 
        }
        reader.Close()
        db.Close();
