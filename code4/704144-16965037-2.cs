    string ID = "test";
    string TrackingPath = "tracking";
    string serverName = "server_name";
    string tmpPath=string.Empty;
    if (serverName != "")
    {
        tmpPath = Path.Combine(@"\\", serverName, TrackingPath ,"u00" + ID);
    }
    Console.WriteLine(tmpPath);
