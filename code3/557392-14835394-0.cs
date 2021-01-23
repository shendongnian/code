    try {
	System.Configuration.Configuration rootWebConfig =	
		System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebsite");	//create connection string object
	System.Configuration.ConnectionStringSettings connString;
	if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)	{
		connString = rootWebConfig.ConnectionStrings.ConnectionStrings["MyConnectionString"];
		if (connString != null) {
			System.Data.SqlClient.SqlCommand cmd = 
				new System.Data.SqlClient.SqlCommand("MyStoredProcedure", new System.Data.SqlClient.SqlConnection(connString.ConnectionString));
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Connection.Open();
			GridViewResults.DataSource = cmd.ExecuteReader();
			GridViewResults.DataBind();
			cmd.Connection.Close();
			cmd.Connection.Dispose();
		}
		else {
			throw new Exception("No MyConnectionString Connection String found in web.config.");
		}
	}
	else {
		throw new Exception("No Connection Strings found in web.config.");
	}
	}
	catch (Exception) {
		throw;
	}
