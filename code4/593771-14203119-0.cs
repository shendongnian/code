    ConnectionOptions connection = new ConnectionOptions();
    connection.Username = "username";
    connection.Password = "password";
    connection.Authority = "ntlmdomain:DOMAIN";
    ManagementScope scope = new ManagementScope(@"\\" + serverName + @"\root\cimv2", connection);
    scope.Connect();
    ObjectQuery query = new ObjectQuery("select * from Win32_Process");
    ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
    ManagementObjectCollection collection = searcher.Get();
    foreach (ManagementObject obj in collection)
    {
        if (obj["ExecutablePath"] != null)
        {
            string processPath = obj["ExecutablePath"].ToString().Replace(":", "$");
            processPath = @"\\" + serverName + @"\" + processPath;
            FileVersionInfo info = FileVersionInfo.GetVersionInfo(processPath);
            string processDesc = info.FileDescription;
        }
    }
