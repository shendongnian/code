	public static byte[] SerializeObject<T>(T obj)
	{
		try
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				BinaryFormatter xs = new BinaryFormatter();
				xs.Serialize(memoryStream, obj);
				return memoryStream.ToArray();
			}
		}
		catch
		{
			return null;
		}
	}
	public static T DeserializeObject<T>(byte[] xml)
	{
		BinaryFormatter xs = new BinaryFormatter();
		MemoryStream memoryStream = new MemoryStream(xml);
		return (T)xs.Deserialize(memoryStream);
	}
