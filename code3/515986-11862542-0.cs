    string result;
    
    using (StringReader sr = new StringReader(content))
    {
      using (XmlReader xr = XmlReader.Create(sr))
      {
        using (StringWriter sw = new StringWriter())
        {
           xsltCompiled.Transform(xr, null, sw);
          result = sw.ToString();
        }
      }
    }
