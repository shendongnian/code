	public static T Create<T>(string xml)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(T));
		using (StringReader reader = new StringReader(xml))
		{
			T t = (T)serializer.Deserialize(reader);
			reader.Close();
			return t;
		}
	}
	var xml = ds.GetXml();
	var dataSetObjects = Create<NewDataSet>(xml);
