    using System;
    using System.Management;
    using System.ServiceProcess;
    
    var services = ServiceController.GetServices();
    foreach (var service in services)
    	using (var serviceObject = new ManagementObject(new ManagementPath(string.Format("Win32_Service.Name='{0}'", service.ServiceName))))
    		Console.WriteLine($"{service.ServiceName} - {serviceObject["Description"]?.ToString()}..");
