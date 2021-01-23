	/// <summary>
	/// Loads a class instance from an XML file.
	/// </summary>
	/// <param name="fileName">Name of the file to load the data from.</param>
	public static T LoadFromXml(string fileName)
	{
		try
		{
			using (IsolatedStorageFile isolatedStorage = GetIsolatedStorageFile)
			{
				// If the file exists, try and load it it's data.
				if (isolatedStorage.FileExists(fileName))
				{
					using (IsolatedStorageFileStream stream = isolatedStorage.OpenFile(fileName, FileMode.Open))
					{
						XmlSerializer serializer = new XmlSerializer(typeof(T));
						T data = (T)serializer.Deserialize(stream);
						return data;
					}
				}
			}
		}
		// Eat any exceptions unless debugging so that users don't see any errors.
		catch
		{
			if (IsDebugging)
				throw;
		}
		// We couldn't load the data, so just return a default instance of the class.
		return default(T);
	}
	/// <summary>
	/// Gets if we are debugging the application or not.
	/// </summary>
	private static bool IsDebugging
	{
		get
		{
    #if (DEBUG)
			// Extra layer of protection in case we accidentally release a version compiled in Debug mode.
			if (System.Diagnostics.Debugger.IsAttached)
				return true;
    #endif
			return false;
		}
	}
