       using System.Xml;
       XmlTextReader reader = new XmlTextReader(
       Server.MapPath("mycompany.xml"));
        reader.WhitespaceHandling = WhitespaceHandling.None;
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(reader);
        reader.Close();        
        lbNodes.Items.Add("XML Document");
        XmlNode xnod = xmlDoc.DocumentElement;
        AddWithChildren(xnod, 1);
