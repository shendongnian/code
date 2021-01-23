    System.Configuration.Configuration configuration = null;         
    if (System.Web.HttpContext.Current != null)
       configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
    else
      configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
