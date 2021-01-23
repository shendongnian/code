    public static void AppendToXml(
        Stream xmlSource,             // your existing xml - could be from a file, etc
        Stream updatedXmlDestination, // your target xml, could be a different file
        string rootElementName,       // the root element name of your list, e.g. TestModels
        TestModel itemToAppend)       // the item to append
    {
        var writerSettings = new XmlWriterSettings {Indent = true, IndentChars = " " };
        using (var reader = XmlReader.Create(xmlSource))
        using (var writer = XmlWriter.Create(updatedXmlDestination, writerSettings))
        {
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.XmlDeclaration:
                        break;
                    case XmlNodeType.Element:
                        writer.WriteStartElement(reader.Prefix, reader.LocalName, reader.NamespaceURI);
                        if (reader.HasAttributes)
                        {
                            while (reader.MoveToNextAttribute())
                            {
                                writer.WriteAttributeString(reader.Prefix, reader.LocalName, reader.NamespaceURI, reader.Value);
                            }
                        }
                        if (reader.IsEmptyElement) 
                            writer.WriteEndElement();
                        break;
                    case XmlNodeType.EndElement:
                        if (reader.Name == rootElementName)
                        {
                            var serializer = new XmlSerializer(typeof(TestModel));
                            var ns = new XmlSerializerNamespaces();
                            ns.Add("", "");
                            serializer.Serialize(writer, itemToAppend, ns);
                        }
                        writer.WriteEndElement();
                        break;
                    case XmlNodeType.Text:
                        writer.WriteRaw(SecurityElement.Escape(reader.Value));
                        break;
                    case XmlNodeType.CDATA:
                        writer.WriteCData(reader.Value);
                        break;
                }
            }
        }
    }
