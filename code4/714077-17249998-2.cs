    var cmd = new SqlCommand(yourConnection);
    cmd.CommandText = "SELECT yourDateColumn FROM yourTable";
    using (var sr = cmd.ExecuteReader)
    {
      If (sr.Read)
      {
        var yourDateTime = sr.GetDateTime(0);
      }
    }
