         Dictionary<string, Entity> myTbl = new Dictionary<string, Entity>();
         XmlDocument doc = new XmlDocument();
         doc.Load(@"d:\meXml.xml");
         XmlNode root = doc.FirstChild;
         foreach (XmlNode childNode in root.ChildNodes)
         {
            myTbl[childNode.Attributes[0].Value] = new Entity(
               childNode.FirstChild.InnerText, 
               childNode.LastChild.InnerText);
         }
