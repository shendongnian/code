            XmlDocument xmlDoc = new XmlDocument();
            XmlDocument xmlDoc2 = new XmlDocument();
           
            xmlDoc.Load(xmlFile);
            xmlDoc2.Load(xmlFile2);
                      
            XmlNode node = xmlDoc.SelectSingleNode("Root/RuleDTO/RuleID");
            XmlNode node2 = xmlDoc2.SelectSingleNode("Root/RuleDTO[1]/RuleID");
            XmlNode node3 = xmlDoc2.SelectSingleNode("Root/RuleDTO[2]/RuleID");
            if (node != null && node2 != null && node3 != null)
                node3.InnerText = node2.InnerText = node.InnerText;
            xmlDoc2.Save(xmlFile2);
