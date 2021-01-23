    var serviceName = "<your service name here>";
    string objPath = string.Format("Win32_Service.Name='{0}'", serviceName);
    using (var service = new ManagementObject(new ManagementPath(objPath)))
    {
        service.InvokeMethod("ChangeStartMode", new object[] {"Automatic"});
    }
    
    You'll need to add a reference to the System.Management assembly, as well as import the namespace System.Management.
