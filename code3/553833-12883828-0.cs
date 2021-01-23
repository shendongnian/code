    using (var mySqlConn = new SqliteConnection(GlobalVars.connectionString) {
        mySqlConn.Open();
        using (SqliteCommand mySqlCommand = new SqliteCommand(SQL, mySqlConn)) {
            mySqlCommand.ExecuteNonQuery();
            // work with the data
        }
        mySqlConn.Close();
    }
