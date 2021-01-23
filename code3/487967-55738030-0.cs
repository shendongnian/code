    public static void UpdateAppConfig(string tagName, string attributeName, string value)
    {
        var doc = new XmlDocument();
        doc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        var tags = doc.GetElementsByTagName(tagName);
        foreach (XmlNode item in tags)
        {
            var attribute = item.Attributes[attributeName];
            if (!ReferenceEquals(null, attribute))
                attribute.Value = value;
        }
        doc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
    }
