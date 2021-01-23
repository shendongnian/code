    public static void AddIsapiRestriction(string name, string path)
    {
        using (var serverManager = new ServerManager())
        {
            var config = serverManager.GetApplicationHostConfiguration();
            var isapiCgiRestrictionSection = config.GetSection("system.webServer/security/isapiCgiRestriction");
            var isapiCgiRestrictionCollection = isapiCgiRestrictionSection.GetCollection();
            if (isapiCgiRestrictionCollection.ToList().Exists(x => x.GetAttribute("path").Value.ToString() == path))
                return;
            var addElement = isapiCgiRestrictionCollection.CreateElement("add");
            addElement["description"] = name;
            addElement["path"] = path;
            addElement["allowed"] = true;
            isapiCgiRestrictionCollection.Add(addElement);
            serverManager.CommitChanges();              
        }            
    }
