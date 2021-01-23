    using (ShellPropertyCollection properties = new ShellPropertyCollection(filePath))
	{
		foreach (IShellProperty prop in properties)
		{
			string value = (prop.ValueAsObject == null) ? "" : prop.FormatForDisplay(PropertyDescriptionFormatOptions.None);
			Console.WriteLine("{0} = {1}", prop.CanonicalName, value);
		}
	}
	
