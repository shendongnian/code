    XmlReader reader = XmlReader.Create(targetFile);
    
    while (reader.Read())
    {
        switch (reader.NodeType)
        {
            case XmlNodeType.Element:
                if (reader.Name.Equals("Company")
                {
                    // Read the XML Node's attributes and add to string
                }
                break;
        }
    }
