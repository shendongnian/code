    XslCompiledTransform proc = new XslCompiledTransform();
    proc.Load("sheet.xsl");
    
    using (StringReader sr = new StringReader(TextBox1.Text))
    {
      using (XmlReader xr = XmlReader.Create(sr))
      {
        proc.Transform(xr, null, Response.Output);
      }
    }
