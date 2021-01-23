    using (ServerManager serverManager = new ServerManager())
    {
      Configuration config = serverManager.GetApplicationHostConfiguration();
      ConfigurationSection sitesSection = config.GetSection("system.applicationHost/sites");
      ConfigurationElementCollection sitesCollection = sitesSection.GetCollection();
      ConfigurationElement siteElement = FindElement(sitesCollection, "site", "name", @"Default Web Site");
      ConfigurationElementCollection applicationCollection = siteElement.GetCollection();
      ConfigurationElement applicationElement = FindElement(applicationCollection, "application", "path", @"/MyNewVirtualDir");
      ConfigurationElementCollection virtualDirCollection = applicationElement.GetCollection();
      ConfigurationElement virtualDirElement = FindElement(virtualDirCollection, "virtualDirectory", "path", @"/");
      virtualDirElement.Attributes["userName"].Value = "MYDOMAIN\\MyUser";
      virtualDirElement.Attributes["password"].Value = "MyPassword";
      serverManager.CommitChanges();
    }
