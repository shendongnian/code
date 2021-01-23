	param[7].ParameterName = "@DOB";
	if(DOB == null)
	{
		param[7].Value = DBNull.Value;
	}
	else
	{
		param[7].Value = DOB;	
	}
	param[7].SqlDbType = Service.SqlDbType.DateTime;
