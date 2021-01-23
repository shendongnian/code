	/// <summary>
	/// Loads a class instance from an XML file asynchronously.
	/// </summary>
	/// <param name="fileName">Name of the file to load the data from.</param>
	public static async System.Threading.Tasks.Task<T> LoadFromXmlAsync(string fileName)
	{
		try
		{
			var files = await System.Threading.Tasks.Task.Run(() => ApplicationData.Current.LocalFolder.GetFilesAsync(Windows.Storage.Search.CommonFileQuery.OrderByName));
			var file = files.GetResults().FirstOrDefault(f => f.Name == fileName);
			// If the file exists, try and load it it's data.
			if (file != null)
			{
				using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(fileName))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(T));
					T data = (T)serializer.Deserialize(stream);
					return data;
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
