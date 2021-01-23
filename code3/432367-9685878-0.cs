    private static DataTable CreateDataTable()
    {
    	DataTable dt = new DataTable("TableRow");
    	dt.Columns.Add(new DataColumn("ID", typeof(int)));
    	dt.Columns.Add(new DataColumn("ParentID", typeof(int)));
    	return dt;
    }
    public static DataTable GetReportFormatFromXML(string XMLReportFormat)
    {
    	if (XMLReportFormat == string.Empty)
    		return null;
    	StringReader sReader = new StringReader(XMLReportFormat);
    	DataSet ds = new DataSet();
    
    	if (sReader == null)
    		return null;
    	ds.Tables.Add(CreateDataTable());
    	return ds.Tables[0];
    }
