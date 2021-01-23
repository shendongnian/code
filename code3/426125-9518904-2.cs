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
                            // Create a document, which will contain the address element as the root
                            var doc = new XmlDocument();
                            // Create a reader, which only will read the substree <Address> ... until ... </Address>
                            doc.Load(reader.ReadSubtree());
                            // Use XPath to query the nodes, here the "Name" node
                            var name = doc.SelectSingleNode("//Address/Name");
                            // Print node name and the inner text of the node
                            Console.WriteLine("Node: {0}, Inner text: {1}", name.Name, name.InnerText);
                        }
                        break;
                }
            }
        }
    }
