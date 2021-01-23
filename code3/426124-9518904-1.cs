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
                            var node = XNode.ReadFrom(reader) as XElement;
                            var street = node.Element("Street");
                            Console.WriteLine("Name: {0}, value: {1}", street.Name, street.Value);
                        }
                        break;
                }
            }
        }
    }
