    private static void SchemaValidatorHandler(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning || e.Severity == XmlSeverityType.Error)
            {
                //Handle your exception
            }
            
        }
