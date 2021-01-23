      string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\AGENTJ.AGENTJ-PC\Documents\Visual Studio 2010\WebSites\mfaridalam\App_Data\mfaridalam1.accdb;    Persist Security Info=False;";
      using(OleDbConnection conn = new OleDbConnection(connectionString))
      {
          conn.Open();
          string query = "UPDATE [LastInfo] SET [LastAlbum]=@newtable WHERE [LastAlbum]=@lasttable";
          OleDbCommand comd = new OleDbCommand();
          comd.Parameters.Add("@newTable", OleDbType.VarChar);
          comd.Parameters["@newTable"].Value = newtable;
          comd.Parameters.Add("@lastTable", OleDbType.VarChar);
          comd.Parameters["@lastTable"].Value = lasttable;
          comd.CommandText = query;
          comd.Connection = conn;
          comd.ExecuteNonQuery();
      }
