    using(var conn = new SQLite.SQLiteConnection(DatabasePath)) 
    {
      conn.Open();
      using(var tr = conn.BeginTransaction())
      {
        try
        {
          using(var cmd = conn.CreateCommand())
          {
            cmd.Transaction = tr;
            cmd.CommandText = @"insert or replace into Option(Key, Value) 
                                  values ('A', '1')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = @"insert or replace into Option(Key, Value) 
                                  values ('B', '2')";
            cmd.ExecuteNonQuery();
          }
          tr.Commit();
        }
        catch (SQLiteException ex)
        {
          tr.Rollback();
        }
      }
      conn.Close();
    }
