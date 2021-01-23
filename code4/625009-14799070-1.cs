    using(XmlWriter writer = root.CreateNavigator().AppendChild())
    {
        writer.WriteStartElement("profesor", strNamespace);
        writer.WriteElementString("ime", strNamespace, name);
        writer.WriteElementString("prezime", strNamespace, surname);
        writer.WriteEndElement();
    }
