    [Setup]
    if (Manager.Current.Browsers.Count > 1)
    {
       Helpers.KillBrowserProcesses(_browserType);
    }
    if (ActiveBrowser == null || !Process.GetProcessesByName(_processName).Any())
    {
       var retries = 0;
       bool browserOpened;
       do
       {
          try
          {
             browserOpened = true;
             Manager.LaunchNewBrowser(_browserType, true, ProcessWindowStyle.Maximized);
             retries = 0;
          }
          catch
          {
             retries++;
             browserOpened = false;
             Console.WriteLine("Restarting the browser. Retry {0} of {1}", retries,
                                          Configuration.Instance.BrowserOpeningRetries);
             if (Manager.Browsers.Count <= 0) continue;
                Helpers.KillBrowserProcesses(_browserType);
                //foreach (var browser in Manager.Browsers)
                //    browser.Close();
                //if (ActiveBrowser != null)
                //    ActiveBrowser.Close();
          }
       } 
       while (retries < Configuration.Instance.BrowserOpeningRetries && browserOpened == false);
    }
  
    public static void KillBrowserProcesses(BrowserType browserType)
    {
       var browserProcesses = new Process[] {};
       switch (browserType)
       {
          case BrowserType.FireFox:
             browserProcesses = Process.GetProcessesByName("firefox");
             break;
          case BrowserType.InternetExplorer:
             browserProcesses = Process.GetProcessesByName("iexplore");
             break;
       }
       foreach (var browserProcess in browserProcesses)
       {
          try
          {
             browserProcess.Kill();
             browserProcess.WaitForExit();
          }
          catch
          {}
       }
    }
