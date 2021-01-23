       ManagementObjectSearcher searcher =new ManagementObjectSearcher(@"\\" + strIPAddress + @"\root\cimv2", "SELECT * FROM Win32_ComputerSystem"); 
       foreach (ManagementObject queryObj in searcher.Get())
        {
          Console.WriteLine("-----------------------------------");
          Console.WriteLine("Win32_ComputerSystem instance");
          Console.WriteLine("-----------------------------------");
          Console.WriteLine("UserName: {0}", queryObj["UserName"]);
        }
