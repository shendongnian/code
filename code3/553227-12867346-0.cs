    using System.Management;
    
    string logDisk= "c:";
    string CIMObject = String.Format("win32_LogicalDisk.DeviceId='{0}'", logDisk);
    using(ManagementObject mo = new ManagementObject(CIMObject))
    {
        mo.Get();
        Console.WriteLine(mo["FileSystem"]);
    }
