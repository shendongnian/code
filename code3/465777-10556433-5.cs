    public static SqlReader executeProcedure(SqlConnection oConn, string commandName, Dictionary<string, object> params)
    {
        SqlCommand comm = oConn.CreateCommand();
        comm.CommandType = CommandType.StoredProcedure;
        comm.CommandText = commandName;
        if (params != null)
            foreach(KeyValuePair<string, object> kvp in params)
                comm.Parameters.Add(new SqlParameter(kvp.Key, kvp.Value));
        return comm.ExecuteReader();
    }
