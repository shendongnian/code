    public static string UserAppDataPath
    {
      get
      {
        try
        {
          if (ApplicationDeployment.IsNetworkDeployed)
          {
            string str = AppDomain.CurrentDomain.GetData("DataDirectory") as string;
            if (str != null)
              return str;
          }
        }
        catch (Exception ex)
        {
          if (System.Windows.Forms.ClientUtils.IsSecurityOrCriticalException(ex))
            throw;
        }
        return Application.GetDataPath(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
      }
    }
