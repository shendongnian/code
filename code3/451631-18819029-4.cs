    using Microsoft.WindowsAPICodePack.Shell;
    using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
	using (ShellPropertyCollection properties = new ShellPropertyCollection(filePath))
	{
		foreach (IShellProperty prop in properties)
		{
			string value = (prop.ValueAsObject == null) ? "" : prop.FormatForDisplay(PropertyDescriptionFormatOptions.None);
			Console.WriteLine("{0} = {1}", prop.CanonicalName, value);
		}
	}
	using (ShellObject shell = ShellObject.FromParsingName(filePath))
	{
		// alternatively: shell.Properties.GetProperty("System.Media.Duration");
        IShellProperty prop = shell.Properties.System.Media.Duration; 
        // Duration will be formatted as 00:44:08
		string duration = prop.FormatForDisplay(PropertyDescriptionFormatOptions.None);
	}
