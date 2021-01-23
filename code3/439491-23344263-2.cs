    private void SearchEventViewer(string computerName, string userName, string userPass)
    {
        var scope = CreateManagementScope(computerName, userName, userPass);
        var startTime = ManagementDateTimeConverter.ToDmtfDateTime(DateTime.UtcNow.AddMinutes(-30));
        var query = new SelectQuery("SELECT * FROM Win32_NTLogEvent WHERE Logfile = 'Security' AND EventType = '5' AND TimeGenerated > '" + startTime + "'");
        using (var searcher = new ManagementObjectSearcher(scope, query))
        {
            var result = searcher.Get();
            foreach (var item in result)
            {
                var eventTimeLocal = DateTime.SpecifyKind(ManagementDateTimeConverter.ToDateTime(item["TimeGenerated"].ToString()), DateTimeKind.Local);
                var eventTimeUtc   = eventTimeLocal.ToUniversalTime();
                var eventDetails = item["Message"].ToString().Replace("\r\n\r\n", "\r\n");
                eventDetails += "\r\nEventCode: "     + item["EventCode"];
                eventDetails += "\r\nCatogory: "      + item["Category"];
                eventDetails += "\r\nRecord Number: " + item["RecordNumber"];
                eventDetails += "\r\nLocal Time: "    + eventTimeLocal.ToString("yyyy-MM-dd HH:mm:ss");
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
