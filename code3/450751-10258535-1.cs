    private static void Enable32BitAppOnWin64IIS7(string serverName, string appPoolName)
    {
      Console.Out.WriteLine("Setting Enable32BitAppOnWin64 for {0} (IIS7)", appPoolName);
      using (DirectoryEntry appPools = 
        new DirectoryEntry(String.Format("IIS://{0}/W3SVC/AppPools/{1}", serverName, appPoolName)))
      {
        appPools.Properties["Enable32BitAppOnWin64"].Value = true;
        appPools.CommitChanges();
      }
    }
