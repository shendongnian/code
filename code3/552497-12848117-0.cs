    public static DataTable GetDataSet(
        SqlParameterHash parameters, string sql, string connectionString,
        CommandType commandType = CommandType.StoredProcedure
    )
    {
        DataSet ds = new DataSet();
        UseDataAdapter(
           parameters, sql, connectionString,
           da => da.Fill(ds), commandType
        );
        return ds;
    }
    public static DataTable GetDataTable(
        SqlParameterHash parameters, string sql, string connectionString,
        CommandType commandType = CommandType.StoredProcedure
    )
    {
        DataTable dt = new DataTable();
        UseDataAdapter(
           parameters, sql, connectionString,
           da => da.Fill(dt), commandType
        );
        return dt;
    }
    public static void UseDataAdapter(
        SqlParameterHash parameters, string sql, string connectionString,
        Action<SqlDataAdapter> adapterAction,
        CommandType commandType = CommandType.StoredProcedure
    )
    {
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, connection);
        da.SelectCommand.CommandType = commandType;
        da.SelectCommand.CommandTimeout = 0;
        foreach (SqlParameter Parameter in parameters)
        { da.SelectCommand.Parameters.Add(Parameter); }
        adapterAction(da);
        da.SelectCommand.Parameters.Clear();
        return dt;
    }
