	/// <summary>
	/// Saves the given class instance as XML asynchronously.
	/// </summary>
	/// <param name="fileName">Name of the xml file to save the data to.</param>
	/// <param name="classInstanceToSave">The class instance to save.</param>
	public static async void SaveToXmlAsync(string fileName, T classInstanceToSave)
	{
		using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(fileName, CreationCollisionOption.ReplaceExisting))
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			using (XmlWriter xmlWriter = XmlWriter.Create(stream, new XmlWriterSettings() { Indent = true }))
			{
				serializer.Serialize(xmlWriter, classInstanceToSave);
			}
		}
	}
