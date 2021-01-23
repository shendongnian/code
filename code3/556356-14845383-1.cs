	XDocument xdoc;
	using (StringReader stringReader = new StringReader(text))
	{
		XmlReaderSettings xmlReaderSettings = new XmlReaderSettings { CheckCharacters = false, DtdProcessing = DtdProcessing.Parse, MaxCharactersFromEntities = 10000000L, XmlResolver = null };
		using (XmlReader xmlReader = XmlReader.Create(stringReader, xmlReaderSettings))
		{
			xdoc = XDocument.Load(xmlReader);
		}
	}
