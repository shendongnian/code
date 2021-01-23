    w.WriteStartElement(this.Prefix, this.LocalName, this.NamespaceURI);
    if (this.HasAttributes)
    {
        XmlAttributeCollection attributes = this.Attributes;
        for (int i = 0; i < attributes.Count; i++)
        {
            attributes[i].WriteTo(w);
        }
    }
    if (this.IsEmpty)
    {
        w.WriteEndElement();
    }
    else
    {
      for (XmlNode node = this.FirstChild; node != null; node = node.NextSibling)
      {
        node.WriteTo(w);
      }
        w.WriteFullEndElement();
    }
