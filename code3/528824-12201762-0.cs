    XDocument doc = new XDocument();
    using (XmlWriter xw = doc.CreateWriter())
    {
      myDataSet.WriteXml(xw);
      xw.Close();
    }
    
    XslCompiledTransform proc = new XslCompiledTransform();
    using (XmlReader xr = XmlReader.Create(myMemoryStream))
    {
      proc.Load(xr);
    }
    
    string result;
    
    using (StringWriter sw = new StringWriter())
    {
      proc.Transform(doc, null, sw);
      result = sw.ToString();
    }
