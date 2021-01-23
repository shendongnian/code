      string computerName="MyPc";
      System.Management.ManagementScope ms = new System.Management.ManagementScope(@"\\" + computerName + @"\root\cimv2");
      System.Management.SelectQuery sq = new System.Management.SelectQuery("SELECT * FROM Win32_Process");
      System.Management.ManagementObjectSearcher mos = new System.Management.ManagementObjectSearcher(ms,sq);
      foreach (System.Management.ManagementObject mo in mos.Get())
      {
        Console.WriteLine(mo["Name"].ToString());
      }
      Console.Read();
