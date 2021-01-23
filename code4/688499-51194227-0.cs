        string cDescription = "";
        ManagementObject serviceObject = new ManagementObject(new ManagementPath(string.Format("Win32_Service.Name='{0}'", item.Name)));
        try
        {
            cDescription = serviceObject["Description"].ToString();
        }
        catch(Exception ex)
        {
            cDescription = ex.Message; // or just leave it empty!
        }
