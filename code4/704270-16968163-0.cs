    public void ExecuteSQLCeNonQuery(string _Sql, IEnumerable<SqlParameter> parameters)
    {
        ...
        foreach(SqlParameter parameter in parameters)
        {
            cmd.Parameters.Add(parameter);
        }
        ...
    }
