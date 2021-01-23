    public static SqlReader executeProcedure(SqlConnection oConn, string commandName)
    {
        SqlCommand comm = oConn.CreateCommand();
        comm.CommandType = CommandType.StoredProcedure;
        comm.CommandText = commandName;
        return comm.ExecuteReader();
    }
