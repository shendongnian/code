    using Microsoft.SqlServer.Management.Smo.Wmi;
    ....
    ManagedComputer mc = new ManagedComputer();
    foreach (ServerInstance si in mc.ServerInstances)
    {
         Console.WriteLine("The installed instance name is " + si.Name);
    }
