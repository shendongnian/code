        string cDescription = "";
        ServiceController[] services = ServiceController.GetServices();
        foreach(var serviceItem in services)
        {
            ManagementObject serviceObject = new ManagementObject(new ManagementPath(string.Format("Win32_Service.Name='{0}'", serviceItem.ServiceName)));
            try
            {
                cDescription = serviceObject["Description"].ToString();
            }
            catch(Exception ex)
            {
                cDescription = ex.Message; // or just leave it empty!
            }
        }
