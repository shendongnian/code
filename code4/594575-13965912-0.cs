    public Composite Read(Stream stream)
    {
    	_errors = null;
    	var settings = new XmlReaderSettings();
    	using (var fileStream = File.OpenRead(XmlComponentsXsd))
    	{
    		using (var schemaReader = new XmlTextReader(fileStream))
    		{
    			settings.Schemas.Add(null, schemaReader);
    			settings.ValidationType = ValidationType.Schema;
    			settings.ValidationEventHandler += OnValidationEventHandler;
    			using (var xmlReader = XmlReader.Create(stream, settings))
    			{
    				var serialiser = new XmlSerializer(typeof (Composite));
    				return (Composite) serialiser.Deserialize(xmlReader);
    			}
    		}
    	}
    }
    private ValidationEventArgs _errors = null;
    private void OnValidationEventHandler(object sender, ValidationEventArgs validationEventArgs)
    {
    	_errors = validationEventArgs;
    }
