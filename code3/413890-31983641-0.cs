    XElement container = new XElement("container");
    
    using (XmlWriter w = container.CreateWriter()) {
    
      DataTable.WriteXml(w, System.Data.XmlWriteMode.WriteSchema, true);
     }
