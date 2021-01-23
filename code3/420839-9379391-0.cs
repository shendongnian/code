    public void ReadXml(System.Xml.XmlReader reader)
    {
            //Skip whitespaces
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            //Create a reader that will read the list's content
            System.Xml.XmlReader subReader = XmlReader.Create(reader.ReadSubtree(), settings);
            subReader.MoveToContent();
            subReader.ReadStartElement();
            while (subReader.Depth > 0)
            {
                Type type = Type.GetType(this.GetType().Namespace + "." + reader.Name);
                parameters.Add((Port)new XmlSerializer(type).Deserialize(subReader));
            }
            reader.ReadEndElement();
    }
