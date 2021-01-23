    public static Tuple<bool, string> ValidateXml(string xmlSchemaFile, string sourceXml) {
            var internalValidationErrors = new XmlSchemaValidationErrorCollection();
            ValidationEventHandler handler = (sender, args) => internalValidationErrors.Add(args);
            var settings = new XmlReaderSettings { ValidationType = ValidationType.Schema };
            try {
                // Set the validation settings. 
                settings = new XmlReaderSettings { ValidationType = ValidationType.Schema };
                settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
                settings.ValidationEventHandler += handler;
                using(var reader = XmlReader.Create(xmlSchemaFile)) {
                    settings.Schemas.Add(null, reader);
                }
                if(settings.Schemas.Count == 0)
                    return Tuple.Create(false, "Missing schema file.");
                // Create the XmlReader object for xml
                using(var reader = XmlReader.Create(sourceXml, settings)) {
                    // Parse the file.  
                    while(reader.Read()) {}
                }
                var validationErrors = internalValidationErrors;
                return Tuple.Create(validationErrors.Any(), validationErrors.ToString());
            }
            finally {
                settings.ValidationEventHandler -= handler;
            }
        }
    public class XmlSchemaValidationErrorCollection : List<ValidationEventArgs>
    {
        internal XmlSchemaValidationErrorCollection()
        { }
        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var validationError in this)
            {
                builder.Append("-Validation Error-");
                builder.AppendFormat("Message: {0} \r\n", validationError.Message);
                builder.AppendFormat("Severity: {0} \r\n", Enum.GetName(typeof(XmlSeverityType), validationError.Severity));
                builder.AppendFormat("Exception: {0} \r\n", validationError.Exception.GetDeepMessage());
                builder.Append("\r\n");
            }
            return base.ToString();
        }
    }
