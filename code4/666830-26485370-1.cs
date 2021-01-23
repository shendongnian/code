    public static OracleParameter CreateCustomTypeArrayInputParameter<T>(string name, string oracleUDTName, T value)
    			where T : INullableOracleCustomType
    		{
    			OracleParameter parameter = new OracleParameter();
    			parameter.ParameterName = name;
    			parameter.OracleDbType = OracleDbType.Array;
    			parameter.Direction = ParameterDirection.Input;
    			parameter.UdtTypeName = oracleUDTName;
    			parameter.Value = value;
    			return parameter;
    		}
