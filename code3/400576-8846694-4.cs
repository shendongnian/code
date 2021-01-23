	public DataSet GetFillGvds(string param_1, string param_2) {
	
	try
	{
	    DataSet oDS = new DataSet();
	    SqlParameter[] oParam = new SqlParameter[2];
	
	
	    oParam[0] = new SqlParameter("@Param1", GetDataValue(param_1));
	    oParam[1] = new SqlParameter("@Param1", GetDataValue(param_2));
	
	    oDS = SqlHelper.ExecuteDataset(DataConnectionString, CommandType.StoredProcedure, "spTest", oParam);
	    return oDS;
	}
	catch (Exception e)
	{
	    ErrorMessage = e.Message;
	    return null;
	}
	}
