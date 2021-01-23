    List<XDocument> schemas = new List<XDocument>();
    foreach (XmlSchema schema in schemaSet.Schemas())
    {
      XDocument schemaDoc = new XDocument();
      using (XmlWriter xw = schemaDoc.CreateWriter())
      {
         schema.Write(xw);
      }
      schemas.Add(schemaDoc);
    }
