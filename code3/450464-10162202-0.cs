	XElement Load(string xml)
	{
		using (var reader = new StringReader(xml))
			return XElement.Load(reader);
	}
	string ProcessStyles(string input)
	{
		var root = Load(input);
		var styleAttributes = root.Descendants().Select(e => e.Attribute(XName.Get("style"))).Where(a => a != null);
		foreach (var styleAttribute in styleAttributes)
		{
			var value = styleAttribute.Value;
			var newValue = value.Split(';').Where(v => v.Trim().StartsWith("color"));
			styleAttribute.SetValue(string.Join(";", newValue));
		}
		return root.ToString();
	}
