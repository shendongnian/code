    public static void CreateNewHouse()
    {
        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
        doc.XmlResolver = null;
        doc.Load(@"d:\House.xml");
        foreach (System.Xml.XmlNode applianceNode in doc.DocumentElement.SelectNodes("/House/Kitchen/Appliance/Name[text()='Refrigerator']"))
        {
            System.Xml.XmlNode modelNode = applianceNode.ParentNode.SelectSingleNode("./Model");
            modelNode.InnerText = "SomeOtherValue";
        }
        doc.Save(@"d:\MyHouse.xml");
    }
