	var xpath = new Stack<string>();
	var settings = new XmlReaderSettings
				   {
					   ValidationType = ValidationType.Schema,
					   ValidationFlags = XmlSchemaValidationFlags.ReportValidationWarnings,
				   };
	MyXmlValidationError error = null;
	settings.ValidationEventHandler += (sender, args) => error = ValidationCallback(sender, args);
	foreach (var schema in schemas)
	{
		settings.Schemas.Add(schema);
	}
	using (var reader = XmlReader.Create(xmlDocumentStream, settings))
	{
		// validation
		while (reader.Read())
		{
			if (reader.NodeType == XmlNodeType.Element)
			{
				xpath.Push(reader.Name);
			}
			if (error != null)
			{
				// set "failing XPath"
				error.XPath = xpath.Reverse().Aggregate(string.Empty, (x, y) => x + "/" + y);
				// your error with XPath now
				error = null;
			}
			if (reader.NodeType == XmlNodeType.EndElement ||
				(reader.NodeType == XmlNodeType.Element && reader.IsEmptyElement))
			{
				xpath.Pop();
			}
		}
	}
