    using Microsoft.SqlServer.Management.Smo.Wmi;
    const string instanceName = "SQLEXPRESS";
    var managedComputer = new ManagedComputer();
    var service = managedComputer.Services[string.Concat("MSSQL$", instanceName)];
    if (service.ServiceState == ServiceState.Running)
    {
        service.Stop();
    }
    var serverInstance = managedComputer.ServerInstances[instanceName];
    var serverProtocol = serverInstance.ServerProtocols["Tcp"];
    var ipAddresses = serverProtocol.IPAddresses;
    for (var i = 0; i < ipAddresses.Count; i++)
    {
        var ipAddress = ipAddresses[i];
        if (!string.Equals(ipAddress.Name, "IPAll"))
        {
            continue;
        }
        ipAddress.IPAddressProperties["TcpPort"].Value = "1433";
        break;
    }
    serverProtocol.Alter();
    service.Start();
