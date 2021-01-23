        public static bool ValidateXmlFile1(string filePath, XmlSchemaSet set)
        {
            bool bValidated = true;
            try
            {
                XmlDocument tmpDoc = new XmlDocument();
                tmpDoc.Load(filePath);
                tmpDoc.Schemas = set;
                ValidationEventHandler eventHandler = new ValidationEventHandler(
                    (Object sender, ValidationEventArgs e) =>
                    {
                        switch (e.Severity)
                        {
                            case XmlSeverityType.Error:
                                {
                                    Debug.WriteLine("Error: {0} on file [{1}]", e.Message, filePath);
                                } break;
                            case XmlSeverityType.Warning:
                                {
                                    Debug.WriteLine("Error: {0} on file [{1}]", e.Message, filePath);
                                } break;
                        }
                        bValidated = false;
                    }
                );
                tmpDoc.Validate(eventHandler);
            }
            catch
            {
                bValidated = false;
            }
            return bValidated;
        }
