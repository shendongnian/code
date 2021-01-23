    using (SQLiteConnection conn = new SQLiteConnection("conn string")) {
      using (SQLiteCommand cmd = conn.CreateCommand()) {
        sqlcmd.CommandText = txtQuery;
        sqlcmd.ExecuteNonQuery();    
      }
    }
