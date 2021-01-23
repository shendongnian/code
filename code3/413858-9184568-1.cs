    public static byte[] WriteObject<T>(T thingToSave)
    {
        Console.WriteLine("Serializing an instance of the object.");
    	byte[] bytes;
    	using(var stream = new MemoryStream())
    	{
    		var serializer = new DataContractSerializer(typeof(T));
    	    serializer.WriteObject(stream, thingToSave);
    		bytes = new byte[stream.Length];
    		stream.Position = 0;
    		stream.Read(bytes, 0, (int)stream.Length);
    	}
    	return bytes;
    	
    }
    
    public static T ReadObject<T>(byte[] data)
    {
    	Console.WriteLine("Deserializing an instance of the object.");
    	
    	T deserializedThing = default(T);
    	
    	using(var stream = new MemoryStream(data))
    	using(var reader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas()))
    	{
    		var serializer = new DataContractSerializer(typeof(T));
    
    		// Deserialize the data and read it from the instance.
    		deserializedThing = (T)serializer.ReadObject(reader, true);
    	}
    	return deserializedThing;
    }
