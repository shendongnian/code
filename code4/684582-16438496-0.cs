    string xml;
    
    using (StringWriter sw = new StringWriter())
    {
      using (XmlWriter xw = XmlWriter.Create(sw, new XmlWriterSettings() { Indent = true }))
      {
        xw.WriteStartDocument();
        xw.WriteStartElement("Root");
        foreach (HtmlElement el in webBrowser1.Document.GetElementsByTagName("TEXTAREA"))
        {
          xw.WriteStartElement("Item");
          xw.WriteElementString("GUID", el.Id);
          xw.WriteElementString("Type", el.GetAttribute("type").ToUpper());
          // write further elements the same way
          xw.WriteEndElement();
        }
        xw.WriteEndElement();
        xw.WriteEndDocument();
      }
      xml = sw.ToString();
    }
