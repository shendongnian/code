    // Get the data that the customer has entered
    TextReader textReader = new StreamReader(fileName);
    // Create the validating reader
    XmlReader schemaReader = XmlReader.Create(schemaStream);
    XmlReaderSettings settings = new XmlReaderSettings();
    settings.Schemas.Add(null, schemaReader);
    settings.ValidationType = ValidationType.Schema;
    var documentReader = XmlReader.Create(textReader, settings);
    // Use the validating reader to read
    try 
    {
        while (documentReader.Read())
        {
        }
    }
    catch (XmlSchemaValidationException ex) 
    {
        //do logging or whatever here
    }
