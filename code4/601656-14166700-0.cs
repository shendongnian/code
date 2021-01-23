    static SqlParameter GetIntSqlParameter(string name, int value)
    {
        SqlParameter parm = new SqlParameter(name, SqlDbType.Int);
        parm.Value = value;
        return parm;
    }
