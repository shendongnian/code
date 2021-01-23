    using Microsoft.SqlServer.Management.Smo.Wmi;
    const string instanceName = "SQLEXPRESS";
    var managedComputer = new ManagedComputer();
    var serviceController = new ServiceController(string.Concat("MSSQL$", instanceName));
    var serverInstance = managedComputer.ServerInstances[instanceName];
    var serverProtocol = serverInstance?.ServerProtocols["Tcp"];
    var ipAddresses = serverProtocol?.IPAddresses;
    if (ipAddresses != null)
    {
        for (var i = 0; i < ipAddresses?.Count; i++)
        {
            var ipAddress = ipAddresses[i];
            if (!string.Equals(ipAddress.Name, "IPAll"))
            {
                continue;
            }
            if (serviceController.Status == ServiceControllerStatus.Running)
            {
                serviceController.Stop();
    
                serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
            }
            ipAddress.IPAddressProperties["TcpDynamicPorts"].Value = "0";
            ipAddress.IPAddressProperties["TcpPort"].Value = "1433";
            serverProtocol.Alter();
            break;
        }
    }
    if (serviceController.Status == ServiceControllerStatus.Running)
    {
        return;
    }
    serviceController.Start();
    serviceController.WaitForStatus(ServiceControllerStatus.Running);
