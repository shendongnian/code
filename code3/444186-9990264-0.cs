            string query = "SELECT * FROM Win32_OperatingSystem";           
            ConnectionOptions connection = new ConnectionOptions();
            if (machineName != "127.0.0.1") // if it is localhost an error'll occur
            {
                connection.Username = admLogon;
                connection.Password = admPassword;
            }
            connection.EnablePrivileges = true;
            connection.Impersonation = ImpersonationLevel.Impersonate;
            ManagementScope managementScope = new ManagementScope(@"\\" + machineName + @"\root\CIMV2", connection);
            managementScope.Connect();
            ObjectQuery queryObj = new ObjectQuery(query);
            ManagementObjectSearcher searcher = new   ManagementObjectSearcher(managementScope, queryObj);
          
            foreach (ManagementObject managementObj in searcher.Get())
            {
               string osName = managementObj.Properties["Caption"].Value.ToString();
               string systemName = managementObj.Properties["csname"].Value;
               string osVersion = managementObj.Properties["Version"].Value;
               string manufacturer = managementObj.Properties["Manufacturer"].Value;
               //etc
            }
           
