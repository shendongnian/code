    public int Insert_Query(string strSQL, SqlParameter[] prm)
    {
        using(SqlConnection con = OpenConnection())
        {
            sqlcmd = new SqlCommand(strSql, con);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddRange(prm)
            int Result = sqlcmd.ExecuteNonQuery();
            return Result;
        }
    }
