    public void SaveMonsterData<T>(T objGraph, string fileName)
    {
        XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
        using (Stream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            xmlFormat.Serialize(fileStream, objGraph);
        }       
    }
    public T LoadMonsterData<T>(string fileName)
	{
		XmlSerializer xmlDeformat = new XmlSerializer(typeof(T));
		T t;
		using (StreamReader fileStream = new StreamReader(fileName))
		{
			t = (T)xmlDeformat.Deserialize(fileStream);
		}
		return t;
	}
