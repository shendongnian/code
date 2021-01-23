        public static byte[] WriteObject<T>(T thingToSave)
    	{
    	    Console.WriteLine("Serializing an instance of the object.");
    		MemoryStream writer = new MemoryStream();
    		DataContractSerializer ser =
    			new DataContractSerializer(typeof(T));
    		ser.WriteObject(writer, thingToSave);
    		byte[] bytes = new byte[writer.Length];
    		writer.Position = 0;
    		writer.Read(bytes, 0, (int)writer.Length);
    		writer.Close();
    		return bytes;
    		
    	}
    
    	public static T ReadObject<T>(byte[] data)
    	{
    		Console.WriteLine("Deserializing an instance of the object.");
    		MemoryStream fs = new MemoryStream(data);
    
    		XmlDictionaryReader reader =
    			XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
    		DataContractSerializer ser = new DataContractSerializer(typeof(Person));
    
    		// Deserialize the data and read it from the instance.
    		T deserializedThing =
    			(T)ser.ReadObject(reader, true);
    		reader.Close();
    		fs.Close();
    		return deserializedThing;
    	}
