    XmlReader reader = XmlReader.Create(targetFile);
    
    while (reader.Read())
    {
        switch (reader.NodeType)
        {
            case XmlNodeType.Element:
                // Do stuff
                break;
            case XmlNodeType.EndElement:
                // Do stuff
                break;
        }
    }
