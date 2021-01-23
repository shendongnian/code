    String wcfNamespace = String.Format(@"\\{0}\Root\ServiceModel", "MachineName");
    ConnectionOptions connection = new ConnectionOptions();
    connection.Authentication = AuthenticationLevel.PacketPrivacy;
    ManagementScope scope = new ManagementScope(wcfNamespace, connection);
    scope.Connect();
    ObjectQuery query = new ObjectQuery("Select * From Service");
    ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
    ManagementObjectCollection queryCollection = searcher.Get();
    ManagementObject[] listing = queryCollection.OfType<ManagementObject>().ToArray();
    Dictionary<int, int> portToPID = new Dictionary<int, int>();
    foreach (ManagementObject mo in queryCollection)
    {
        //each of services only have one base address in my example
        Uri baseAddress = new Uri(((Array)mo.Properties["BaseAddresses"].Value).GetValue(0).ToString());
        int pid = Int32.Parse(mo.Properties["ProcessId"].Value.ToString());
        portToPID.Add(baseAddress.Port, pid);
    }
