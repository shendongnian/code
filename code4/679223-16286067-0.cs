	ReportExecutionService rs = new ReportExecutionService();
	rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
	rs.Url = "http://MyServer/ReportServer/ReportExecution2005.asmx";
	arguments
	byte[] result = null;
	string reportPath = "/ReportLuiza/ReportContract";
	string format = "PDF";
	// Prepare report parameter.
	ParameterValue[] parameters = new ParameterValue[1];
	parameters[0] = new ParameterValue();
	parameters[0].Name = "NMB_CONTRACT";
	parameters[0].Value = txtNmbContractReport.Text;
	string encoding;
	string mimeType;
	string extension;
	Warning[] warnings = null;
	string[] streamIDs = null;
	ExecutionInfo execInfo = new ExecutionInfo();
	ExecutionHeader execHeader = new ExecutionHeader();
	rs.ExecutionHeaderValue = execHeader;
	execInfo = rs.LoadReport(reportPath, null);
	rs.SetExecutionParameters(parameters, "pt-br");
	String SessionId = rs.ExecutionHeaderValue.ExecutionID;
	try
	{
	   result = rs.Render(format, null, out extension, out encoding, out mimeType, out warnings, out streamIDs);
	   execInfo = rs.GetExecutionInfo();
	}
	catch (SoapException se)
	{
		ShowMessage(se.Detail.OuterXml);
	}
	// Write the contents of the report to an pdf file.
	try
	{
		/*
		using (FileStream stream = new FileStream(@"c:\report.pdf", FileMode.Create, FileAccess.ReadWrite))
		{
			stream.Write(result, 0, result.Length);
			stream.Close();
		}
		*/
		Response.Clear();
		Response.ContentType = "application/pdf";
		Response.AddHeader("Content-Disposition", "attachment;filename=\"report.pdf\"");
		Response.BinaryWrite(result);
		Response.Flush();
		Response.End();
	}
	catch (Exception ex)
	{
		ShowMessage(ex.Message);
	}
