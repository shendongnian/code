    XmlTextReader reader = new XmlTextReader ("file.xml");
    
    XmlWriter writer = XmlWriter.Create("first_file.xml")
    writer.WriteStartDocument();
    
    int treeDepth = 0;
    
    while (reader.Read()) 
    {
        switch (reader.NodeType) 
        {
            case XmlNodeType.Element:
    
                //
                // Move to parsing or skip the root node
                //
                
                if (treeDepth > 0)
                    writer.WriteStartElement(reader.Name);
    
                treeDepth++;
    
                
                break;
      case XmlNodeType.Text:
    
                //
                // Write text here
                //
    
                writer.WriteElementString (reader.Value);
    
                break;
      case XmlNodeType.EndElement:
    
                //
                // Close the end element, open new file
                //
    
                if (treeDepth == 1)
                {
                    writer.WriteEndDocument();
                    writer = new XmlWriter("file2.xml");
                    writer.WriteStartDocument();
                }
    
                treeDepth--;
    
                break;
        }
    }
    
    writer.WriteEndDocument();
