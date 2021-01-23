                FileStream fs;
            XmlSchema schema;
            ValidationEventHandler eventHandler = new ValidationEventHandler(Class1.ShowCompileErrors);
            try
            {
                fs = new FileStream("book.xsd", FileMode.Open);
                schema = XmlSchema.Read(fs, eventHandler);
                schema.Compile(eventHandler);
                XmlSchemaSet schemaSet = new XmlSchemaSet();
                schemaSet.Add(schema);
                schemaSet.Compile();
                schema = schemaSet.Schemas().Cast<XmlSchema>().First();
                var simpleTypes = schema.SchemaTypes.Values.OfType<XmlSchemaSimpleType>()
                                                   .Where(t => t.Content is XmlSchemaSimpleTypeRestriction);
                foreach (var simpleType in simpleTypes)
                {
                    XmlSchemaSimpleTypeRestriction restriction = (XmlSchemaSimpleTypeRestriction)simpleType.Content;
                    
                    XmlSchemaEnumerationFacet actorEnum = new XmlSchemaEnumerationFacet();
                    actorEnum.Value= "Actor";
                    restriction.Facets.Add(actorEnum);
                    XmlSchemaEnumerationFacet producerEnum = new XmlSchemaEnumerationFacet();
                    producerEnum.Value = "Producer";
                    restriction.Facets.Add(producerEnum);
                    
                }
                fs.Close();
                fs = new FileStream("book.xsd", FileMode.Create);
                schema.Write(fs);
                fs.Flush();
                fs.Close();
            }
            catch (XmlSchemaException schemaEx)
            {
                Console.WriteLine(schemaEx.Message);
            }
            catch (XmlException xmlEx)
            {
                Console.WriteLine(xmlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.Read();
            }
