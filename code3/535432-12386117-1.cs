    // Return an array of SqlParameter's by using reflection on ParamObject
    private static SqlParameter[] GetParametersFromObject( object ParamObject )
    {
        var Params = new List<SqlParameter>();
        foreach( var PropInfo in ParamObject.GetType().GetProperties() )
        {
            Params.Add( new SqlParameter( PropInfo.Name, PropInfo.GetValue( ParamObject, null ) ) );
        }
        return Params.ToArray();
    }
    public static void ExecuteSP( SqlConnection Connection, string SPName, object ParamObject )
    {
        using( var Command = new SqlCommand() )
        {
            Command.Connection = Connection;
            Command.CommandType = CommandType.StoredProcedure;
            Command.CommandText = SPName;
            Command.Parameters.AddRange( GetParametersFromObject( ParamObject ) );
            // Command.ExecuteReader()...
        }
    }
