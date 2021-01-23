	string strConnection = ConfigurationManager.ConnectionStrings["oConnection"].ConnectionString;
	dataConnection = new OracleConnectionStringBuilder(strConnection);
	OracleConnection oConnection = new OracleConnection(dataConnection.ToString());
	oConnection.Open();
	OracleCommand tmpCommand = oConnection.CreateCommand();
	tmpCommand.Parameters.Add("user", OracleDbType.Varchar2, txtUser.Text, ParameterDirection.Input);
	tmpCommand.CommandText = "SELECT USER, PASS FROM TB_USERS WHERE USER = :1";
	try
	{
		OracleDataReader tmpReader = tmpCommand.ExecuteReader(CommandBehavior.SingleRow);
		
		if (tmpReader.HasRows)
		{
			// PT: IMPLEMENTE SEU CÓDIGO	
			// ES: IMPLEMENTAR EL CÓDIGO
			// EN: IMPLEMENT YOUR CODE
		}
	}
	catch(Exception e)
	{
			// PT: IMPLEMENTE SEU CÓDIGO	
			// ES: IMPLEMENTAR EL CÓDIGO
			// EN: IMPLEMENT YOUR CODE
	}
