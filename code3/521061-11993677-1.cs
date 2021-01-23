    try
    {
      //Create the new application domain
      AppDomainSetup ads = new AppDomainSetup();
      ads.ApplicationBase = Path.GetDirectoryName(config.ExePath) + @"\";
      ads.ConfigurationFile = 
        Path.GetDirectoryName(config.ExePath) + @"\" + config.ExeName + ".config";
      ads.ShadowCopyFiles = "false";
      ads.ApplicationName = config.ExeName;
      AppDomain newDomain = AppDomain.CreateDomain(config.ExeName + " Domain", 
        AppDomain.CurrentDomain.Evidence, ads);
      //Execute the application in the new appdomain
      retValue = newDomain.ExecuteAssembly(config.ExePath, 
        AppDomain.CurrentDomain.Evidence, null);
      //Unload the application domain
      AppDomain.Unload(newDomain);
    }
    catch (Exception e)
    {
      Trace.WriteLine("APPLICATION LOADER: Failed to start application at:  " + 
        config.ExePath);
      HandleTerminalError(e);
    }
