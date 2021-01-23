    using (var reader = XmlReader.Create("file.xml"))
    {
        while (reader.Read())
        {
            switch (reader.NodeType)
            {
            case XmlNodeType.Text:
            case XmlNodeType.CDATA:
            case XmlNodeType.EntityReference:
            case XmlNodeType.Whitespace:
            case XmlNodeType.SignificantWhitespace:
               Console.Write("{0}", reader.ReadContentAsString());
               break;
            }
        }
    }
