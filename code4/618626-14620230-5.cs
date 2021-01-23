    using (var xsdStream = new MemoryStream(fXmlSchema))
            {
                xsdStream .Position = 0;
                using (var xsdReader = XmlReader.Create(xsdStream ))
                {
                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.ValidationType = ValidationType.Schema;
                    settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
                    settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
                    settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
                    settings.Schemas.Add(XmlSchema.Read(xsdReader , [performingValidationCallback]));
                    using (var xmlStream = new MemoryStream(fXml))
                    {
                        using (var xmlReader = XmlReader.Create(xmlStream, settings ))
                        {
                            try
                            {
                                xmlStream .Position = 0;
                                while (xmlReader .Read())
                                {
                                }
                            }
                            catch (XmlException e)
                            {
                                //VALIDATIONERROR
                            }
                        }
                    }
                }
            }
