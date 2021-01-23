    using (SqliteConnection conn = new SqliteConnection(@"Data Source=:memory:")) 
    {
      conn.Open();
      using(SqliteTransaction trans = conn.BeginTransaction())
      {
        using (SqliteCommand cmd = new SQLiteCommand(conn))
        {
          cmd.CommandText = File.ReadAllText(@"file.sql");
          cmd.ExecuteNonQuery();
        }
        trans.Commit();
      }
      con.Close();
    }
