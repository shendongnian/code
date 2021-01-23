    private void ChanngeDefaultPassword(string password)
    {
        try
        {
            System.Configuration.Configuration objConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            objConfig.AppSettings.Settings["DEFAULT_PASSWORD"].Value = password;
            objConfig.Save();
         }
         catch (Exception ex)
         {
         }
    }
