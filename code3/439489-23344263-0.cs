    private void SearchEventViewer(string computerName, string userName, string userPass)
    {
        var scope     = CreateManagementScope(computerName, userName, userPass);
        var startTime = ManagementDateTimeConverter.ToDmtfDateTime(DateTime.UtcNow.AddMinutes(-30));
        var query     = new SelectQuery("SELECT * FROM Win32_NTLogEvent WHERE Logfile = 'Security' AND EventType = '5' AND TimeWritten > '" + startTime + "'");
    
        using (var searcher = new ManagementObjectSearcher(scope, query))
        {
            foreach (var item in result)
            {
                var eventTime    = ManagementDateTimeConverter.ToDateTime(result["TimeWritten"].ToString()).ToString("yyyy_MM_dd_H_mm_ss");
                var eventDetails = item["Message"].ToString().Replace("\r\n\r\n", "\r\n");
                eventDetails    += "\r\nEventCode: " + item["EventCode"] + "\r\nCatogory: " + item["Category"] + "\r\n";
                
                // Do something...
             }
        }
    }
    
    private ManagementScope CreateManagementScope(string computerName, string username = "", string password = "")
    {
        var managementPath = @"\\" + computerName + @"\root\cimv2";
        var scope = new ManagementScope(managementPath);
    
        if (username != "" && password != "")
        {
            scope.Options = new ConnectionOptions
            {
                Username = username,
                Password = password,
                Impersonation = ImpersonationLevel.Impersonate,
                Authentication = AuthenticationLevel.PacketPrivacy
            };
        }
    
        return scope;
    }
