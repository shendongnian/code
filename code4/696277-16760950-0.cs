	System.Xml.Schema.XmlSchemaSet xset = ...; // Loaded somehow
	System.Xml.XmlQualifiedName qn = ...; // LocalName + NamespaceURI
	if (xset.GlobalElements.Contains(qn))
	{
		System.Xml.Schema.XmlSchemaElement el = (System.Xml.Schema.XmlSchemaElement)xset.GlobalElements[qn];
		if (!el.IsAbstract)
		{
			// The XML file may implement the schemata loaded in this schema set.
		}
	}
