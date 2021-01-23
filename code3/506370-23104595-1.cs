    using (var connection = new SqlConnection("Data Source=.;Integrated Security=SSPI"))
    {
        var serverConnection = new ServerConnection(connection);
        var server = new Server(serverConnection);
        var defaultDataPath = string.IsNullOrEmpty(server.Settings.DefaultFile) ? server.MasterDBPath : server.Settings.DefaultFile;
        var defaultLogPath = string.IsNullOrEmpty(server.Settings.DefaultLog) ? server.MasterDBLogPath : server.Settings.DefaultLog;
    }
