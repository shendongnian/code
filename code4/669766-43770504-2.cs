        // Changes an encrypted database to unencrypted and removes password
        string connString = "Data Source=c:\\test.db3;Password=something";    
        SQLiteConnection conn = new SQLiteConnection(connString);
        conn.SetPassword("");
        //conn.Open();    // doesn't work because connString hasn't been updated
        // Update connString
        connString = "Data Source=c:\\test.db3;";    
        conn = new SQLiteConnection(connString);
        conn.Open();  // we've opened the DB without a password
        // Re-encrypts the database. The connection remains valid and usable afterwards until closed - then the connection string needs updating.    
        conn.ChangePassword("somethingelse");
        conn.Close();
        // Update connString
        connString = "Data Source=c:\\test.db3;Password=somethingelse";   
        conn = new SQLiteConnection(connString); // must re-instantiate!
        conn.Open();  // we've opened the DB with our new password
  
