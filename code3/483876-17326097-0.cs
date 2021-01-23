    try
    {
    
    	//First, find the version of the currently installed SQL Server Instance
    	string sqlString = "SELECT SUBSTRING(CONVERT(VARCHAR, SERVERPROPERTY('productversion')), 0, 5)";
    	string sqlInstanceVersion = string.Empty;                
    
        //_database was initialized elsewhere - it's from Enterprise Library
    	using (DbCommand cmd = _database.GetSqlStringCommand(sqlString))
    	{
    		sqlInstanceVersion = cmd.ExecuteScalar().ToString();
    	}
    
    	if (sqlInstanceVersion.Equals(String.Empty))
    	{
    		//TODO throw an exception or do something else
    	}
    
    	//11.00 = SQL2012, 10.50 = SQL2008R2, 10.00 = SQL2008, 9.00 = SQL2005, 8.00 = SQL2000
    	switch (sqlInstanceVersion)
    	{
    		case "11.00":
    		case "10.50":
    		case "10.00":
    			//Log that the version is already up to date and return
    			return;
    		case "9.00":
    		case "8.00":
    			//We are on SQL 2000 or 2005, so continue with upgrade to 2008R2
    			break;
    		default:
    			//TODO throw an exception for unsupported SQL Server version
    			break;
    	}
    
    	string upgradeArgumentString = "/Q /ACTION=upgrade /INSTANCENAME={0} /ENU /IACCEPTSQLSERVERLICENSETERMS";
    	string instanceName = "YourInstanceNameHere";
    	string installerFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\SQLEXPR_x86_ENU.exe";	
    
    	if (!File.Exists(installerFilePath))
    	{
    		throw new FileNotFoundException(string.Format("Unable to find installer file: {0}", installerFilePath));
    	}
    
    	Process process = new Process
    	{
    		StartInfo = { FileName = installerFilePath, Arguments = String.Format(upgradeArgumentString, instanceName), UseShellExecute = false }
    	};
    
    	process.Start();
    
    	if (process.WaitForExit(SQLSERVER_UPGRADE_TIMEOUT))
    	{
    		//Do something here when the process completes within timeout.
    		//Probably look at exit code, or whatever to determine if it was successful
    	}
    	else
    	{
    		//The process exceeded timeout.  Do something about it; like throw exception, or whatever
    	}
    }
    catch(Exception ex)
    {
    	//Handle your exceptions here
    }
