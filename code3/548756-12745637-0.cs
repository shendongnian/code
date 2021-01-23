      XmlDocument doc = new XmlDocument(); 
      doc.LoadXml(); // file path of the XML you provided in your question.
      XmlNode nameElem = doc.CreateNode("element", "Name", "");  
      nameElem.InnerText = "Darren Davies";
      XmlNode availableProducts = doc.CreateNode("element", "AvailProducts", "");  
      availableProducts.InnerText = "Product";
      XmlNode cost = doc.CreateNode("element", "Cost", "");  
      cost.InnerText = "Cost";
      XmlElement root = doc.DocumentElement;
      root.AppendChild(nameElem); // Append the new name element
      root.AppendChild(availableProducts);
      root.AppendChild(cost);
