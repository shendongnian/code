    using (var conn = new SqlConnection(@"server=(local)\sql2008;database=Junk;Integrated Security=SSPI"))
    {
      conn.Open();
      // Repeat this block as often as you like...
      using (var tran = conn.BeginTransaction())
      {
        using (var cmd = new SqlCommand("INSERT INTO Mess VALUES ('mess1')", conn, tran))
        {
          cmd.ExecuteNonQuery(); // Shows in Sql profiler
        }
        tran.Commit(); // Commits
      }
      using (var cmd = new SqlCommand("INSERT INTO Mess VALUES ('mess2')", conn))
      {
        cmd.ExecuteNonQuery(); // Executes and commits (implicit transaction).
      }
    }
