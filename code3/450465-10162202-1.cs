	XElement Load(string xml)
	{
		using (var reader = new StringReader(xml))
			return XElement.Load(reader);
	}
	string ProcessStyles(string input)
	{
		var root = Load(input);
		var allElements = root.Descendants();
		var styleAttributes = allElements.Select(e => e.Attribute(XName.Get("style"))).Where(a => a != null);
		foreach (var styleAttribute in styleAttributes)
		{
			var value = styleAttribute.Value;
			var newValue = ProcessCss(value);
			styleAttribute.SetValue(newValue);
		}
		return root.ToString();
	}
	string ProcessCss(string value)
	{
		var cssTokens = value.Split(';').Select(t => t.Trim());
		
		// implement your filtering rules here
		var filtered = cssTokens.Where(t => t.StartsWith("color"));
		return String.Join(";", filtered);
	}
