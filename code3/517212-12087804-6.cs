    public class SomeClass
    {
  
        List<XElement> errorElements = new List<XElement>();
  
        public void Load()
        {
        
            // Set the validation settings.
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
            
            // Create the XmlReader object.
            XmlReader reader = XmlReader.Create("xml/note.xml", settings);
            
            // Load the XDocument from the reader
            XDocument loadedDoc = XDocument.Load(reader);
            // do something with errorElements
        
        }
        public void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            var exception = (args.Exception as XmlSchemaValidationException);
            if (exception != null)
            {
                var element = (exception.SourceObject as XElement);
    
                if (element != null)
                    errorElements.Add(element);
             }
        }
    
    }
