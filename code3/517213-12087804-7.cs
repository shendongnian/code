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
        foreach (var node in loadedDoc.Descendants())
        {
            var si = node.GetSchemaInfo();
        }
    }
