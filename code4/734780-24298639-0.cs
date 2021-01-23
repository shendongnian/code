    foreach (HostSystem host in vmHosts)
    {
    HostConfigManager hostConfigManager = host.ConfigManager;
    HostDateTimeSystem hostDateTimeSystem = (HostDateTimeSystem) vimClient.GetView(hostConfigManager.DateTimeSystem, null));
    DateTime hostDateTime = hostDateTimeSystem.QueryDateTime();
    }
