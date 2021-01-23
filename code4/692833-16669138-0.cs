    public ActionResult GetError()
    {
      XmlDocument xdoc=GetXMLError();
      XslCompiledTransform xsl = new XslCompiledTransform();
      xsl.Load(@"D:\Development\Test.xsl");
      XmlReader xReader = XmlReader.Create(new StringReader(xdoc.InnerXml));
      StringBuilder stringBuilder=new StringBuilder();
      XmlWriter xWriter=XmlWriter.Create(stringBuilder);
      xsl.Transform(xReader, xWriter);
      return View(stringBuilder);
    }
    
