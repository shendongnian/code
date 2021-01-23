     using(XmlReader reader = XmlReader.Create("1234.xml"))
     {
          while (reader.Read())
          {
               if (reader.NodeType == XmlNodeType.Element)
               {
                    if (reader.Name.ToLower() == "data")
                    {
                        string xml = reader.ReadOuterXml();
    
                        var xmlString = (from data in XDocument.Parse(xml).Elements()
                                                 select data.Elements().First().Value).FirstOrDefault();
    
                         xmlString = xmlString.Replace("\n", "").Trim();
    
                         // Your other operations
                     }
                }
           }
      }
