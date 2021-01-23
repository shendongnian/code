    public string XMLValidation(string XMLString, string SchemaPath)
        {
            string error = string.Empty;
            MemoryStream xmlStream = new MemoryStream(Encoding.UTF8.GetBytes(XMLString));
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(null, SchemaPath);
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas.Add(schemas);
            settings.ValidationEventHandler += new ValidationEventHandler(delegate(object sender, ValidationEventArgs e)
            {
                switch (e.Severity)
                {
                    case XmlSeverityType.Error:
                        XmlReader senRder = (XmlReader)sender;
                        if (senRder.NodeType == XmlNodeType.Attribute)
                        {//when error occurs in an attribute,get its parent element name
                            string attrName = senRder.Name;
                            senRder.MoveToElement();
                            error += string.Format("ERROR:ElementName'{0}':{1}{2}", senRder.Name, e.Message, Environment.NewLine);
                            senRder.MoveToAttribute(attrName);
                        }
                        else
                        {
                            error += string.Format("ERROR:ElementName'{0}':{1}{2}", senRder.Name, e.Message, Environment.NewLine);
                        }
                        break;
                    case XmlSeverityType.Warning:
                        break;
                }
            });
            XmlReader xmlRdr = XmlReader.Create(xmlStream, settings);
            while (xmlRdr.Read()) ;
            return error;
        }
