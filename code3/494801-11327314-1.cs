    using (OracleConnection conn = new OracleConnection("User Id=oraDB;Password=ora;Data Source=CCT"))
     {
          string query = "SELECT idcard from CallCardTable where idcard=:CallCardNo";
          using(OracleCommand cmd = new OracleCommand(query, conn))
           {
                conn.Open();
                cmd.Parameters.Add(":CallCardNo", OracleType.VarChar,20).Value = CallCardNo;
                OracleDataAdapter dA = new OracleDataAdapter(cmd);
                dA.Fill(ds);
            }
      }
      return ds.GetXml();
