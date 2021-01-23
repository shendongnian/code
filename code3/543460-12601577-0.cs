    ManagementObjectSearcher MyWMIQuery = new ManagementObjectSearcher("SELECT * FROM Win32_Product WHERE CAPTION LIKE \"%office%\" ");
    ManagementObjectCollection MyWMIQueryCollection = MyWMIQuery.Get();
    foreach (ManagementObject MyMO in MyWMIQueryCollection)
    {
    	Console.WriteLine("Caption : " + MyMO["Caption"].ToString());
    	Console.WriteLine("InstallLocation : " + (MyMO["InstallLocation"] == null ? " " : MyMO["InstallLocation"].ToString()));
    }
