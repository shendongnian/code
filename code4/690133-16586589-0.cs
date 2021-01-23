    object resultContent;
	if (condition)
	{
		//if content is XmlElement
		resultContent = new XElement("result", "....");
	}
	else
	{
		resultContent = "Text";
	}
	XDocument xDoc = new XDocument(new XElement("results", resultContent));
