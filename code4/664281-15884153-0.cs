    static void Main(string[] args)
    {
        string strQuery = "SELECT * FROM WIN32_PROCESSOR";
        string strIPAddress = "XXX.XXX.X.XXX";
        DataTable dtProcessor = new DataTable();
        dtProcessor.Columns.Add("CAPTION");
        dtProcessor.Columns.Add("L2CACHESIZE");
        dtProcessor.Columns.Add("L3CACHESIZE");            
    
        ManagementScope scope = new ManagementScope(@"\\" + strIPAddress + @"\root\cimv2");
        SelectQuery query = new SelectQuery();
        query.QueryString = strQuery;
        ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
        ManagementObjectCollection queryCollection = searcher.Get();
        List<string> properties = new List<string>();
        foreach (ManagementObject mngmntObj in queryCollection)
        {
           if (properties.Count==0)
           {
             foreach (PropertyData property in mngmntObj.Properties)
             properties.Add(property.Name);
           }
            DataRow dr = dtProcessor.NewRow();
            dr["CAPTION"] = mngmntObj["CAPTION"];
            dr["L2CACHESIZE"] = mngmntObj["L2CACHESIZE"];
            if (properties.Contains("L3CACHESIZE", StringComparer.OrdinalIgnoreCase))
            {
            dr["L3CACHESIZE"] = mngmntObj["L3CACHESIZE"];
            }
            dtProcessor.Rows.Add(dr);
    
        }
    }
