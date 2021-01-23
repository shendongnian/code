    public SqlDataReader GetRS(string sqlText, SqlParameter[] prm)
    {
          ....
          SqlCommand cmd = new SqlCommand(sqlText, conn);
          cmd.Parameters.AddRange(prm);
          .....
    }
