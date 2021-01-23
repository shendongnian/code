     using (System.Data.Common.DBConnection conn = getConn())
     {
      DbCommand com = conn.CreateCommand();
      DbDataAdapter da = CreateAdapter(com);
      // .. properties of adapter ..
      da.Fill(ds);
     }
