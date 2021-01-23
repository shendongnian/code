    public static void SaveAppSetting(string key, string value)
	{
		Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
		SaveUsingXDocument(key, value, config.AppSettings.ElementInformation.Source);
	}
	/// <summary>
	/// Saves the using an XDocument instead of ConfigSecion.
	/// </summary>
	/// <remarks>
	/// The built-in <see cref="T:System.Configuration.Configuration"></see> class removes all XML comments when modifying the config file.
	/// </remarks>
	private static void SaveUsingXDocument(string key, string value, string fileName)
	{
		XDocument document = XDocument.Load(fileName);
		if ( document.Root == null )
		{
			return;
		}
		XElement appSetting = document.Root.Elements("add").FirstOrDefault(x => x.Attribute("key").Value == key);
		if ( appSetting != null )
		{
			appSetting.Attribute("value").Value = value;
			document.Save(fileName);
		}
	}
