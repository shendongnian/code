    public string ReadXfa(PdfReader reader) {
      XfaForm xfa = new XfaForm(reader);
      XmlDocument doc = xfa.DomDocument;
      reader.Close();
      
      if (!string.IsNullOrEmpty(doc.DocumentElement.NamespaceURI)) {
        doc.DocumentElement.SetAttribute("xmlns", "");
        XmlDocument new_doc = new XmlDocument();
        new_doc.LoadXml(doc.OuterXml);
        doc = new_doc;
      }
      var sb = new StringBuilder(4000);
      var Xsettings = new XmlWriterSettings() {Indent = true};
      using (var writer = XmlWriter.Create(sb, Xsettings)) {
        doc.WriteTo(writer);
      }
      return sb.ToString();    
    }
