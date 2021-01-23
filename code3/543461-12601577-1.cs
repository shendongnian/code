    Using System.Management
        
        ManagementObjectSearcher WMIQuery = new ManagementObjectSearcher("SELECT * FROM Win32_Product WHERE CAPTION LIKE \"%office%\" ");
        ManagementObjectCollection WMIQueryCollection = WMIQuery.Get();
            
        foreach (ManagementObject MO in WMIQueryCollection)
        {
            Console.WriteLine("Caption : " + MO["Caption"].ToString());
            Console.WriteLine("InstallLocation : " + (MO["InstallLocation"] == null ? " " : MO["InstallLocation"].ToString()));
        }
