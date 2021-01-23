	var xdoc = XDocument.Parse(ToFix);
	foreach (var person in xdoc.Elements("person"))
	{
		var name = person.Attribute("name");
		if (person.LastAttribute != name)
		{
			person.RemoveAttributes();
			person.SetAttributeValue(name.Name, name.Value + "-Example");
		}
	}
	var output = xdoc.ToString();
