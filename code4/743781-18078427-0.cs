    /// <summary>
    /// change the icon in add/remove programs     
    /// </summary>
    private static void SetProgramInstallIcon()
    {
      //run only when deployed 
      if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed
         && ApplicationDeployment.CurrentDeployment.IsFirstRun)
      {
        try
        {
          string iconSourcePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "YourFancyIcon.ico");
          if (!File.Exists(iconSourcePath))
            return;
    
          RegistryKey myUninstallKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
          string[] mySubKeyNames = myUninstallKey.GetSubKeyNames();
          for (int i = 0; i < mySubKeyNames.Length; i++)
          {
            RegistryKey myKey = myUninstallKey.OpenSubKey(mySubKeyNames[i], true);
            object myValue = myKey.GetValue("DisplayName");
            if (myValue != null && myValue.ToString() == "YourApplicationDisplayName")
            {
              myKey.SetValue("DisplayIcon", iconSourcePath);
              break;
            }
          }
        }
        catch (Exception ex) {
          //manage errors as you like (log, UI, ...)
        }
      }
    }
