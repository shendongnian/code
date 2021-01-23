    private void GenerateReport()
    {
    	ReportExecutionService rs = new ReportExecutionService();
    	rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
    	rs.Url = "http://<TFS server name>/reportserver/ReportExecution2005.asmx";
    
    	// Render arguments
    	byte[] result = null;
    	string reportPath = @"<SSRS report path>";
    	string format = "PDF";
    	string historyID = null;
    	string devInfo = @"<DeviceInfo><Toolbar>False</Toolbar></DeviceInfo>";
    
    	// Prepare report parameter.
    	ParameterValue[] parameters = new ParameterValue[2];
    	parameters[0] = new ParameterValue();
    	parameters[0].Name = "StartDateParam";
    	parameters[0].Value = "2012-06-01 00:00:00";
    	parameters[1] = new ParameterValue();
    	parameters[1].Name = "EndDateParam";
    	parameters[1].Value = "2012-09-01 00:00:00";
        parameters[2] = new ParameterValue();
        parameters[2].Name = "AreaParam";
        parameters[2].Value = "[Work Item].[Area Hierarchy].[<area path>]";
        parameters[3] = new ParameterValue();
        parameters[3].Name = "WorkItemTypeParam";
        parameters[3].Value = "[Work Item].[System_WorkItemType].&[Task]";
        parameters[4] = new ParameterValue();
        parameters[4].Name = "StateParam";
        parameters[4].Value = "[Work Item].[System_State].&[Active]";
        parameters[5] = new ParameterValue();
        parameters[5].Name = "TrendLineParam";
        parameters[5].Value = "both";
    	DataSourceCredentials[] credentials = null;
    	string showHideToggle = null;
    	string encoding;
    	string mimeType;
    	string extension;
    	Warning[] warnings = null;
    	ParameterValue[] reportHistoryParameters = null;
    	string[] streamIDs = null;
    	
    	ExecutionInfo execInfo = new ExecutionInfo();
    	ExecutionHeader execHeader = new ExecutionHeader();
    
    	rs.ExecutionHeaderValue = execHeader;
    
    	execInfo = rs.LoadReport(reportPath, historyID);
    
    	var parameters_ = rs.GetExecutionInfo().Parameters;
    
    	rs.SetExecutionParameters(parameters, "en-us"); 
    	String SessionId = rs.ExecutionHeaderValue.ExecutionID;
    
    	Console.WriteLine("SessionID: {0}", rs.ExecutionHeaderValue.ExecutionID);
    
    	try
    	{
    		result = rs.Render(format, devInfo, out extension, out encoding, out mimeType, out warnings, out streamIDs);
    
    		execInfo = rs.GetExecutionInfo();
    
    		Console.WriteLine("Execution date and time: {0}", execInfo.ExecutionDateTime);
    
    	}
    	catch (SoapException e)
    	{
    		Console.WriteLine(e.Detail.OuterXml);
    	}
    	// Write the contents of the report to an MHTML file.
    	try
    	{
    		FileStream stream = File.Create("report.pdf", result.Length);
    		Console.WriteLine("File created.");
    		stream.Write(result, 0, result.Length);
    		Console.WriteLine("Result written to the file.");
    		stream.Close();
    	}
    	catch (Exception e)
    	{
    		Console.WriteLine(e.Message);
    	}
    
    }
