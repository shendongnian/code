    private static Version GetIISVerion()
    {
      using (RegistryKey inetStpKey = 
        Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\InetStp"))
      {
        int majorVersion = (int)inetStpKey.GetValue("MajorVersion");
        int minorVersion = (int)inetStpKey.GetValue("MinorVersion");
        return new Version(majorVersion, minorVersion);
      }
    }
    private static void Enable32BitAppOnWin64IIS7(string appPoolName)
    {
      Console.Out.WriteLine("Setting Enable32BitAppOnWin64 for {0} (IIS7)", appPoolName);
      using (ServerManager serverMgr = new ServerManager())
      {
        ApplicationPool appPool = serverMgr.ApplicationPools[appPoolName];
        if (appPool == null)
        {
          throw new ApplicationException(String.Format("The pool {0} does not exist", appPoolName));
        }
        appPool.Enable32BitAppOnWin64 = true;
        serverMgr.CommitChanges();
      }
    }
    private static void Enable32BitAppOnWin64IIS6(string serverName)
    {
      Console.Out.WriteLine("Setting Enable32BitAppOnWin64 for IIS6");
      using (DirectoryEntry appPools = 
        new DirectoryEntry(String.Format("IIS://{0}/W3SVC/AppPools", serverName)))
      {
        appPools.Properties["Enable32BitAppOnWin64"].Value = true;
        appPools.CommitChanges();
      }
    }    
    public static void Enable32BitAppOnWin64(string serverName, string appPoolName)
    {
      Version v = GetIISVerion(); // Get installed version of IIS
      Console.Out.WriteLine("IIS-Version: {0}", v);
      if (v.Major == 6) // Handle IIS 6
      {
        Enable32BitAppOnWin64IIS6(serverName);
        return;
      }
      if (v.Major == 7) // Handle IIS 7
      {        
        Enable32BitAppOnWin64IIS7(appPoolName);
        return;
      }
      throw new ApplicationException(String.Format("Unknown IIS version: {0}", v.ToString()));
    }
    static void Main(string[] args)
    {
      Enable32BitAppOnWin64(Environment.MachineName, "DefaultAppPool");
    }
