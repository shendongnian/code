    static internal string GetSqlConnectionString(){
	try {
		ConnectionStringSettings mySetting = ConfigurationManager.ConnectionStrings("DataBaseConnection");
		if (mySetting == null)
			throw new Exception("Database connection settings have not been set in Web.config file");
		return mySetting.ConnectionString;
	} catch (Exception ex) {
		throw;
	}}
