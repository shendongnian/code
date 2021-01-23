            XmlWriterSettings writerSettings = null;
            XsltArgumentList transformationArguments = null;
            XslCompiledTransform transformer = null;
            MemoryStream memoryStream = null;
            XPathDocument xPathDocument = null;
            StringBuilder sb = null;
            XmlWriter writer = null;
            XmlDocument resultXml = null;
            try
            {
                writerSettings = new XmlWriterSettings();
                writerSettings.OmitXmlDeclaration = true;
                writerSettings.Indent = true;
                transformationArguments = new XsltArgumentList();
                transformer = new XslCompiledTransform();
                memoryStream = new MemoryStream(System.Text.Encoding.Default.GetBytes(xml.OuterXml));
                xPathDocument = new XPathDocument(new StreamReader(memoryStream));
                sb = new StringBuilder();
                writer = XmlWriter.Create(sb, writerSettings);
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    transformationArguments.AddParam(parameter.Key, string.Empty, parameter.Value);
                }
                using (Stream strm = Assembly.GetExecutingAssembly().GetManifestResourceStream("Lib.XSLTFile1.xslt"))
                using (XmlReader reader = XmlReader.Create(strm))
                {
                    transformer.Load(reader);
                    transformer.Transform(xPathDocument, transformationArguments, writer);
                }
                resultXml = new XmlDocument();
                resultXml.LoadXml(sb.ToString());
                // for testing only
                File.AppendAllText(@"Your path goes here\result.xml", resultXml.OuterXml);
            }
            catch (Exception)
            {
                throw;
            }
