        var textReader = new XmlTextReader("...\\YourFile.xml");
        // Read until end of file
        while (textReader.Read())
        {
            XmlNodeType nType = textReader.NodeType;
            // If node type us a declaration
            if (nType == XmlNodeType.XmlDeclaration)
            {
                Console.WriteLine("Declaration:" + textReader.Name.ToString());
            }
            // if node type is a comment
            if (nType == XmlNodeType.Comment)
            {
                Console.WriteLine("Comment:" + textReader.Name.ToString());
            }
            // if node type us an attribute
            if (nType == XmlNodeType.Attribute)
            {
                Console.WriteLine("Attribute:" + textReader.Name.ToString());
            }
            // if node type is an element
            if (nType == XmlNodeType.Element)
            {
                Console.WriteLine("Element:" + textReader.Name.ToString());
            }
            // if node type is an entity\
            if (nType == XmlNodeType.Entity)
            {
                Console.WriteLine("Entity:" + textReader.Name.ToString());
            }
            // if node type is a Process Instruction
            if (nType == XmlNodeType.Entity)
            {
                Console.WriteLine("Entity:" + textReader.Name.ToString());
            }
            // if node type a document
            if (nType == XmlNodeType.DocumentType)
            {
                Console.WriteLine("Document:" + textReader.Name.ToString());
            }
            // if node type is white space
            if (nType == XmlNodeType.Whitespace)
            {
                Console.WriteLine("WhiteSpace:" + textReader.Name.ToString());
            }
        }
