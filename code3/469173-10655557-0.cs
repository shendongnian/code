    // This Function creates 
    protected string ConvertToHtml(MemoryStream xmlOutput)
    {
            XPathDocument document = new XPathDocument(xmlOutput);
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(xmlOutput);
            StringWriter writer = new StringWriter();
            XslCompiledTransform transform = new XslCompiledTransform();
            transform.Load(reportDir + "MyXslFile.xsl");
            transform.Transform(xDoc, null, writer);
            xmlOutput.Position = 1;
            // These lines are the problem
            //StreamReader sr = new StreamReader(xmlOutput);
            //return sr.RearToEnd();
            return writer.ToString()
    }
