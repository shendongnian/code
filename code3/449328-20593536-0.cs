            /// <summary>
            /// Ensure all xsd imported xsd documented are in same folder as master xsd
            /// </summary>
            public XsdXmlValidatorResult Validate(string xmlPath, string xsdPath, string xsdNameSpace)
            {
                var result = new XsdXmlValidatorResult();
                var readerSettings = new XmlReaderSettings {ValidationType = ValidationType.Schema};
                readerSettings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema; 
                readerSettings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
                readerSettings.Schemas.Add(null, xsdPath);
                        
                readerSettings.ValidationEventHandler += (sender, args) =>
                    {
                        switch (args.Severity)
                        {
                            case XmlSeverityType.Warning:
                                result.Warnings.Add(args.Message);
                                break;
                            case XmlSeverityType.Error:
                                result.IsValid = false;
                                result.Warnings.Add(args.Message);
                                break;
                        }
                    };
    
                var reader = XmlReader.Create(xmlPath, readerSettings);
    
                while (reader.Read()) { }
    
                return result;
            }
