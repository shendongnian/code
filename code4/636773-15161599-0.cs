    using IBM.Data.DB2;
    public DataSet GetProfileInternet()
    {
    	string v_connection_string = "Database=myDatabase;Server=myServer:myPort;UID=myUserId;PWD=myPassword";
        DB2Connection v_connection = new DB2Connection(v_connection_string);
	    try
            {
		// Open Connection
		v_connection.Open();
		DB2Command cmd = new DB2Command("pr_get_profile_internet", v_connection);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("p_profile_internet_id", DB2Type.Integer);
		cmd.Parameters["p_profile_internet_id"].Direction = ParameterDirection.Input;
		cmd.Parameters["p_profile_internet_id"].Value = 1;
		DB2DataAdapter da = new DB2DataAdapter(cmd);
		DataSet ds = new DataSet("GetProfileInternet");
		da.Fill(ds);
		return ds;
	}
	catch (Exception ex)
	{
		throw ex;
	}
	finally
	{
		if (v_connection != null)
		{
			v_connection.Close();
		}
	}
    }
