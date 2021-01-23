    using (ServerManager serverManager = new ServerManager())
          {
             Configuration config = serverManager.GetWebConfiguration("Contoso");
             ConfigurationSection authorizationSection = config.GetSection("system.webServer/security/authorization");
             ConfigurationElementCollection authorizationCollection = authorizationSection.GetCollection();
    
             ConfigurationElement addElement = authorizationCollection.CreateElement("add");
             addElement["accessType"] = @"Allow";
             addElement["roles"] = @"administrators";
             authorizationCollection.Add(addElement);
    
             serverManager.CommitChanges();
          }
