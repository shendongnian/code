     using (System.Data.Common.DBConnection conn = getConn())
     {
      DbCommand com = conn.CreateCommand();
      DbDataAdapter da = new SqlDataAdapter(com);
      da.Fill(ds);
     }
