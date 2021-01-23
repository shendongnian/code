    using (var inFile = new FileStream(path, FileMode.Open))
    {
        using (var reader = new XmlTextReader(inFile))
        {
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "Address" && reader.GetAttribute(0) == "Work")
                        {
                            // Do stuff to the node
                            var node = XNode.ReadFrom(reader);
                        }
                        break;
                }
            }
        }
    }
