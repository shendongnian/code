        string xmlString = null;
        
        using (StringWriter xmlOutput = new StringWriter())
        {
            XmlDocument xmlDocument = new XmlDocument();
    
            XmlElement productElement = xmlDocument.CreateElement("product");
            
            XmlElement nameElement = xmlDocument.CreateElement("name");
            nameElement.InnerText = pName;
            
            XmlElement priceElement = xmlDocument.CreateElement("price");
            priceElement.InnerText = pPrice;
            
            productElement.AppendChild(nameElement);
            productElement.AppendChild(priceElement);
            xmlDocument.AppendChild(productElement);
            
            xmlDocument.Save(xmlOutput);
            
            xmlString = xmlOutput.ToString();
        }
