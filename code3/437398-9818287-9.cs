    using( SqlCeConnection conn =
              new SqlCeConnection(@"Data Source=|DataDirectory|\dbJournal.sdf") )
    using( SqlCeCommand cmd = conn.CreateCommand() )
    {
      conn.Open();
      //commands represent a query or a stored procedure       
      cmd.CommandText = "SELECT * FROM tblJournal";
      using( SqlCeDataReader rd = cmd.ExecuteReader() )
      {
         //...read
      }
      conn.Close();
    }
