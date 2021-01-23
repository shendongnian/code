    public static OracleCommand CreateStoredProcedureCommand(string name,
                                                             OracleConnection connection)
    {
        OracleCommand result = new OracleCommand(name, connection);
        try
        {
            result.CommandType = CommandType.StoredProcedure;
            return result;
        }
        catch
        {
            result.Dispose();
            throw;
        }
    }
