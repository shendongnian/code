    using System.Management;
    using System.Management.Instrumentation;
    
    ManagementScope scope = new ManagementScope("\\\\RemoteMachineName\\root\\cimv2");
    scope.Connect();
    
    ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Process WHERE Name='ProcessName'");
    ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
    
    ManagementObjectCollection objectCollection = searcher.Get();
    foreach(ManagementObject managementObject in objectCollection)
    {
       managementObject.InvokeMethod("Terminate", null);
    }
