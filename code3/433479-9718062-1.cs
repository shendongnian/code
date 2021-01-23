    using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
    {  
    
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        break;
                    case XmlNodeType.Text:
                        break;
                    case XmlNodeType.EndElement:
                        break;
                }
            }
    
        }
    }
