    using System;
    using System.Management;
    public static string GetServiceDescription(string serviceName)
    {
        using (ManagementObject service = new ManagementObject(new ManagementPath(string.Format("Win32_Service.Name='{0}'", serviceName))))
        {
            return service["Description"].ToString();
        }
    }
