        public bool Validate(XmlReader xmlInput, XmlReader schemaDocument)
        {
            var xmlSchemaSet = new XmlSchemaSet();
            xmlSchemaSet.Add("", schemaDocument);
            try
            {
                var doc = XDocument.Load(xmlInput);
                bool valid = true;
                doc.Validate(xmlSchemaSet, (o, e) =>
                {
                    valid = false;
                });
                return valid;
            }
            catch (Exception e)
            {
                return false;
            }
        }
