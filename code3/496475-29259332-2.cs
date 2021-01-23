    public static void CreateNewHouse()
    {
        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
        doc.XmlResolver = null;
        doc.Load(@"d:\House.xml");
        foreach (System.Xml.XmlNode modelNode in doc.DocumentElement
    .SelectNodes("/House/Kitchen/Appliance/Name[text()='Refrigerator']/../Model"))
        {
            modelNode.InnerText = "A New Value";
        }
        doc.Save(@"d:\MyHouse.xml");
    }
