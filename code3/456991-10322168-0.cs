    String path = @"\\{0}\ROOT\CIMV2";
    String BiosVersion = String.Empty;
    ConnectionOptions co = new ConnectionOptions();
    ManagementScope scope = 
        new ManagementScope(String.Format(path, "."), co);
    scope.Connect();
    ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_BIOS");
    ManagementObjectSearcher search = new ManagementObjectSearcher(scope, query);
    ManagementObjectCollection moc = search.Get();
    foreach (ManagementObject mo in moc)
    {
        BiosVersion = (String)mo["SMBIOSBIOSVersion"];
    }
