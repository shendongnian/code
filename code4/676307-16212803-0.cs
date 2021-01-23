    List<int> idList = yourObjectList;
    List<int> nameList = yourObjectList;
    
    using (OracleConnection oraconn = new OracleConnection())
    {
    	oraconn.ConnectionString = "Your_Connection_string";
    
    	using (OracleCommand oracmd = new OracleCommand())
    	{
    		oracmd.Connection = oraconn;
    
    		oracmd.CommandType = CommandType.StoredProcedure;
    		oracmd.CommandText = "Your_Procedura_name";
    		oraconn.Open();
    
    		// To use ArrayBinding, you need to set ArrayBindCount   
    		oracmd.BindByName = true;
    		oracmd.ArrayBindCount = idList.Count;
    
    		// Instead of single values, we pass arrays of values as parameters   
    		oracmd.Parameters.Add("ids", OracleDbType.Int32, oyourObjectList.ToArray(), ParameterDirection.Input);
    		oracmd.Parameters.Add("names", OracleDbType.Varchar2, oyourObjectList.ToArray(), ParameterDirection.Input);
    
    		oracmd.ExecuteNonQuery();
    		oraconn.Close();
    	}
    }
