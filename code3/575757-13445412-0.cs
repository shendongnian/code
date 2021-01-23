    public static class IsolatedSerializer
	{
		public static void Save<T>(string filename, T t)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(t.GetType());
			using (var store = IsolatedStorageFile.GetUserStoreForApplication())
			using (var stream = store.CreateFile(filename))
			{
				xmlSerializer.Serialize(stream, t);
			}
		}
		
		public static T Load<T>(string filename)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			using (var store = IsolatedStorageFile.GetUserStoreForApplication())
			using (var stream = store.CreateFile(filename))
			{
				return (T)xmlSerializer.Deserialize(stream);
			}
		}	
	}
