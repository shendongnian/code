    DataTable dt = new DataTable();
    dt.Columns.Add("Name");
    dt.Columns.Add("InstallDate");
    dt.Columns.Add("State");
    dt.Columns.Add("ServiceType");
    
    try
    {
        ManagementObjectSearcher searcher =
            new ManagementObjectSearcher("root\\CIMV2",
            "SELECT * FROM Win32_Service");
    
        foreach (ManagementObject queryObj in searcher.Get())
        {
            DataRow dr = dt.NewRow();               
               
            dr["Name"] = queryObj["Name"];
            dr["InstallDate"] = queryObj["InstallDate"];
            dr["ServiceType"] = queryObj["ServiceType"];
            dr["State"] = queryObj["State"];
    
            dt.Rows.Add(dr);
                 
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    catch (ManagementException ex)
    {
        //"An error occurred while querying for WMI data: " + e.Message;
    }
