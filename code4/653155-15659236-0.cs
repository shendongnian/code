    public static string Transform(XmlDocument doc, XmlDocument stylesheet)
        {
            try
            {
                System.Xml.Xsl.XslCompiledTransform transform = new System.Xml.Xsl.XslCompiledTransform();
                transform.Load(stylesheet); // compiled stylesheet
                System.IO.StringWriter writer = new System.IO.StringWriter();
                XmlReader xmlReadB = new XmlTextReader(new StringReader(doc.DocumentElement.OuterXml));
                transform.Transform(xmlReadB, null, writer);
                return writer.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
