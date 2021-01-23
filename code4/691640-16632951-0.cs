    using (XmlWriter xmlWriter = XmlWriter.Create(fStream, xmlSettings))
    {
        xmlWriter.WriteStartDocument(true);
        xmlWriter.WriteStartElement("Friends");
        xmlWriter.WriteStartElement("Friend");
        xmlWriter.WriteElementString("Name", "Safiq");
        xmlWriter.WriteElementString("Like", "Char");
        xmlWriter.WriteElementString("Unlike", "anger");
        xmlWriter.WriteElementString("Nickname", "good");
        xmlWriter.WriteElementString("Gift", "c#");
        xmlWriter.WriteEndElement();
        xmlWriter.WriteEndElement();
        xmlWriter.WriteEndDocument();
        xmlWriter.Flush();
    }
    
    // Reposition The stream
    fStream.Position=0;
    
    XDocument XDOC = XDocument.Load(fStream);
    XElement x = new XElement("Friend");
    x.Add(new XElement("Name", "Safiq"));
    x.Add(new XElement("Like", "Char"));
    x.Add(new XElement("Unlike", "anger"));
    x.Add(new XElement("Nickname", "good"));
    x.Add(new XElement("Gift", "c#"));
    XDOC.Descendants("Friends").Single().Add(x);
    XDOC.Save(fStream);
