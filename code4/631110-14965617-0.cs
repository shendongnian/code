    public List<string> ValidateXml(string xml, string rootXsdName)
        {
            List<string> xsdValidationErrors = new List<string>();
            try
            {
                // Note: Don't use XDocument schema validation as this will give a false positive of a string without XSD specified       
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
                settings.ValidationEventHandler += ((o, e) => xsdValidationErrors.Add(e.Message));
                settings.Schemas = GetXmlSchemas(rootXsdName);
                TextReader textReader = new StringReader(xml);
                XmlReader reader = XmlReader.Create(textReader, settings);
                // Parse the file.          
                while (reader.Read())
                {
                    //Empty control loop to read through entire document getting errors uaing ValidationEventHandler
                }
            }
            catch (Exception ex)
            {
                xsdValidationErrors.Add("Unable to parse XML");
            }
           
            return xsdValidationErrors;
        }
