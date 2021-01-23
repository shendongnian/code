    static public DataTable GetDataTable(SqlParameterHash parameters, string sql,
            string connectionString, CommandType commandType = CommandType.StoredProcedure)
    {
        return GetDataX<DataTable>(parameters, sql, connectionString, (dt, adapter) => { adapter.Fill(dt); }, commandType);
    }
    static public DataSet GetDataSet(SqlParameterHash parameters, string sql,
            string connectionString, CommandType commandType = CommandType.StoredProcedure)
    {
        return GetDataX<DataSet>(parameters, sql, connectionString, (ds, adapter) => { adapter.Fill(ds); }, commandType);
    }
