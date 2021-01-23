            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("informationData.xml");
    
          
            foreach (XmlNode node in xmlDoc)
            {
                Name = node.SelectSingleNode("name").InnerText;
                Surname = node.SelectSingleNode("surname").InnerText;
                TelNumber = Convert.ToInt32(node.SelectSingleNode("tel").InnerText);
    
            }
