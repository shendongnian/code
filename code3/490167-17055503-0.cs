	/// <summary>
	/// Saves the given class instance as XML.
	/// </summary>
	/// <param name="fileName">Name of the xml file to save the data to.</param>
	/// <param name="classInstanceToSave">The class instance to save.</param>
	public static void SaveAsXml(string fileName, T classInstanceToSave)
	{
		using (IsolatedStorageFile isolatedStorage = GetIsolatedStorageFile)
		{
			using (IsolatedStorageFileStream stream = isolatedStorage.OpenFile(fileName, FileMode.Create))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(T));
				using (XmlWriter xmlWriter = XmlWriter.Create(stream, new XmlWriterSettings() { Indent = true }))
				{
					serializer.Serialize(xmlWriter, classInstanceToSave);
				}
			}
		}
	}
	/// <summary>
	/// Gets the Isolated Storage File for the current platform.
	/// </summary>
	private static IsolatedStorageFile GetIsolatedStorageFile
	{
		get
		{
    #if (WINDOWS_PHONE)
			return IsolatedStorageFile.GetUserStoreForApplication();
    #else
			return IsolatedStorageFile.GetUserStoreForDomain();
    #endif
		}
	}
