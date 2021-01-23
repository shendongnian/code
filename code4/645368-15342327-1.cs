    private void buttonOK_Click(object sender, EventArgs e)
       {
            using (ServerManager serverManager = new ServerManager())
            {
                Configuration config = serverManager.GetApplicationHostConfiguration();
                ConfigurationSection isapiCgiRestrictionSection = config.GetSection("system.webServer/security/isapiCgiRestriction");
                ConfigurationElementCollection isapiCgiRestrictionCollection = isapiCgiRestrictionSection.GetCollection();
                foreach (ConfigurationElement element in isapiCgiRestrictionCollection)
                {
                    element.SetAttributeValue("allowed", false);
                }
                ConfigurationElement addElement = isapiCgiRestrictionCollection.CreateElement("add");
                serverManager.CommitChanges();          
            }
        }
