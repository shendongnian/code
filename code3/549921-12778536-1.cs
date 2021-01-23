    OracleCommand oraCommand = new OracleCommand();
    oraCommand.Connection = oraConnection;
    oraCommand.CommandType = CommandType.StoredProcedure;
    oraCommand.CommandText = "procedurename";
    OracleParameter oraParameter = new OracleParameter(":result", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
    oraCommand.Parameters.Add(oraParameter);
    oraCommand.ExecuteNonQuery();
    
    racleDataAdapter oraDataAdapter = new OracleDataAdapter(oraCommand);
    Oracle.DataAccess.Types.OracleRefCursor refCursor = (Oracle.DataAccess.Types.OracleRefCursor)oraParameter.Value;
    OracleDataReader reader = refCursor.GetDataReader();
