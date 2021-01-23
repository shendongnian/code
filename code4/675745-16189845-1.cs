    public int set(string procName , SqlParameter[] param)
            {
                  SqlConnection conn = new SqlConnection(constr);
                  conn.Open();
              SqlCommand cmd = new SqlCommand(procName,conn);
              cmd.CommandType = CommandType.StoredProcedure;
              foreach(SqlParameter o in param)
              {
                 cmd.Parameters.Add(o);      // Error
              }
              int res = cmd.ExecuteNonQuery();
              conn.Close();
              return res;
        })
