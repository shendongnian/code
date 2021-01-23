	public void saveTag()
	{
		using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
		{
			XDocument document;
			XElement tagRegistry = null;
			
			if (storage.FileExists("/tagRegistry.xml"))
			{
				using(var stream = storage.OpenFile("/tagRegistry.xml", FileMode.Open))
				{
					document = XDocument.Load(stream);
				}
				
				tagRegistry = document.Descendants("SmartSafe").FirstOrDefault();
			}
			else
			{
				document = new XDocument();
			}
			
			if(tagRegistry == null)
			{
				tagRegistry = new XElement("SmartSafe");
				document.Add(tagRegistry);
			}
			
			XElement newTag = new XElement("Tag",
				new XElement("tag", stringUid),
				new XElement("name", desiredName),
				new XElement("latitude", latitude),
				new XElement("longitude", longitude));
			
			tagRegistry.Add(newTag);
			
			using (Stream stream = storage.CreateFile("/tagRegistry.xml"))
			{
				document.Save(stream);
			}
		}
	}
