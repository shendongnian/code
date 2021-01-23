    private NameValueCollection GetNameValueCollectionSection(string section, string filePath)
    {
            string file = filePath;
            System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
            NameValueCollection nameValueColl = new NameValueCollection();
            System.Configuration.ExeConfigurationFileMap map = new ExeConfigurationFileMap();
            map.ExeConfigFilename = file;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            string xml = config.GetSection(section).SectionInformation.GetRawXml();
            xDoc.LoadXml(xml);
            System.Xml.XmlNode xList = xDoc.ChildNodes[0];
            foreach (System.Xml.XmlNode xNodo in xList)
            {
                nameValueColl.Add(xNodo.Attributes[0].Value, xNodo.Attributes[1].Value);
            }
            return nameValueColl;
     }
