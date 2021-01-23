    public void ExecuteSQLCeNonQuery(string _Sql, IEnumerable<SqlParameter> parameters)
    {
        ...
        if (parameters != null) // Null check so caller can pass null if there are no parameters
        {
            foreach(SqlParameter parameter in parameters)
            {
                cmd.Parameters.Add(parameter);
            }
            ...
        }
    }
