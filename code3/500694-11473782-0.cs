	private static void SetConnection(ReportDocument report, string databaseName, string serverName, string userName, string password)
	{
		foreach (Table table in report.Database.Tables)
		{
			if (table.Name != "Command")
			{
				SetTableConnectionInfo(table, databaseName, serverName, userName, password);
			}
		}
		foreach (ReportObject obj in report.ReportDefinition.ReportObjects)
		{
			if (obj.Kind != ReportObjectKind.SubreportObject)
			{
				return;
			}
			var subReport = (SubreportObject)obj;
			var subReportDocument = report.OpenSubreport(subReport.SubreportName);
			SetConnection(subReportDocument, databaseName, serverName, userName,  password);
		}
	}
	private static void SetTableConnectionInfo(Table table, string databaseName, string serverName, string userName, string password)
	{
		// Get the ConnectionInfo Object.
		var logOnInfo = table.LogOnInfo;
		var connectionInfo = logOnInfo.ConnectionInfo;
		// Set the Connection parameters.
		connectionInfo.DatabaseName = databaseName;
		connectionInfo.ServerName = serverName;
		connectionInfo.Password = password;
		connectionInfo.UserID = userName;
		table.ApplyLogOnInfo(logOnInfo);
		if (!table.TestConnectivity())
		{
			throw new ApplicationException(Resource.UnableToConnectCrystalReportToDatabase);
		}
		table.Location = Database + "." + "dbo" + "." + table.Location;
	}
