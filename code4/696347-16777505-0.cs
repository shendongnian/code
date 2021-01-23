    using (WordprocessingDocument doc = WordprocessingDocument.Open(@"test.docx", false))
    {
      string wordDocXml = doc.MainDocumentPart.Document.OuterXml;
      XslCompiledTransform xslTransform = new XslCompiledTransform();
      // The OMML2MML.xsl file is located under 
      // %ProgramFiles%\Microsoft Office\Office15\
      xslTransform.Load(@"c:\Program Files\Microsoft Office\Office15\OMML2MML.XSL");
      using (TextReader tr = new StringReader(wordDocXml))
      {
        // Load the xml of your main document part.
        using (XmlReader reader = XmlReader.Create(tr))
        {
          using (MemoryStream ms = new MemoryStream())
          {
            XmlWriterSettings settings = xslTransform.OutputSettings.Clone();
            // Configure xml writer to omit xml declaration.
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            settings.OmitXmlDeclaration = true;
            XmlWriter xw = XmlWriter.Create(ms, settings);
            // Transform our OfficeMathML to MathML.
            xslTransform.Transform(reader, xw);
            ms.Seek(0, SeekOrigin.Begin);
            using (StreamReader sr = new StreamReader(ms, Encoding.UTF8))
            {
              string officeML = sr.ReadToEnd();
              Console.Out.WriteLine(officeML);
            }
          }
        }
      }
    }
