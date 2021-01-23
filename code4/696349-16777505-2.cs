    using System.IO;
    using System.Xml;
    using System.Xml.Xsl;
    using DocumentFormat.OpenXml.Packaging;
    public string GetWordDocumentAsMathML(string docFilePath, string officeVersion = "14")
    {
        string officeML = string.Empty;
        using (WordprocessingDocument doc = WordprocessingDocument.Open(docFilePath, false))
        {
            string wordDocXml = doc.MainDocumentPart.Document.OuterXml;
    
            XslCompiledTransform xslTransform = new XslCompiledTransform();
    
            // The OMML2MML.xsl file is located under 
            // %ProgramFiles%\Microsoft Office\Office15\
            xslTransform.Load(@"c:\Program Files\Microsoft Office\Office" + officeVersion + @"\OMML2MML.XSL");
    
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
                            officeML = sr.ReadToEnd();
                            // Console.Out.WriteLine(officeML);
                        }
                    }
                }
            }
        }
        return officeML;
    }
