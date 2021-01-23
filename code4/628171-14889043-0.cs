    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
    foreach (XmlElement element in xmlDoc.DocumentElement)
    {
        if (element.Name.Equals("appSettings"))
        {
            foreach (XmlNode node in element.ChildNodes)
            {
                if (node.Attributes[0].Value.Equals("SaveWindowItemsMap"))
                {
                    node.Attributes[1].Value = "New Value";
                }
            }
        }
    }
    xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
    ConfigurationManager.RefreshSection("appSettings");
