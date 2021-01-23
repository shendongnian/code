     Microsoft.Reporting.WebForms.LocalReport oLocalReport = objReportViewer.LocalReport;
	 
	byte[] renderedBytes = null;
	string reportType = "PDF";
    string mimeType = "application/pdf";
	string encoding = null;
	Microsoft.Reporting.WebForms.Warning[] warnings = null;
	string[] streams = null;
    string deviceInfo = "<DeviceInfo><OutputFormat>PDF</OutputFormat><PageWidth>8.5in</PageWidth><PageHeight>11in</PageHeight></DeviceInfo>";
	//Render the report
	renderedBytes = oLocalReport.Render(reportType, deviceInfo, mimeType, encoding, "PDF", streams, warnings);
	System.Web.HttpContext.Current.Response.Clear();
	System.Web.HttpContext.Current.Response.ContentType = mimeType;
	System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + _reportName + ".PDF");
	System.Web.HttpContext.Current.Response.BinaryWrite(renderedBytes);
	System.Web.HttpContext.Current.Response.End();
