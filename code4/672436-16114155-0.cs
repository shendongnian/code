                using (OracleCommand cmd = new OracleCommand())
              {
                OracleConnection conn;
                conn = new OracleConnection(ConnectionStringOracle);
                cmd.ArrayBindCount = listSize.Count();
                cmd.CommandText = "package.insertR";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.Parameters.Add(new OracleParameter(":firstList", OracleDbType.Varchar2, 32767));
                cmd.Parameters[":firstList"].Value = rd.fl.ToArray();
                cmd.Parameters.Add(new OracleParameter(":secondList", OracleDbType.Varchar2, 32767));
                cmd.Parameters[":secondList"].Value = rd.sl.ToArray();
                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                  conn.Close();
