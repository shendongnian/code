    public class JSONSerializer<T>
    {
	    public static string Serialize(T obj)
	    {
		    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
		    using (MemoryStream stream = new MemoryStream()) {
			    serializer.WriteObject(stream, obj);
			    return Encoding.Default.GetString(stream.ToArray());
		    }
	    }
	    public static T Deserialize(string json)
	    {
		    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
		    using (MemoryStream stream = new MemoryStream(Encoding.Default.GetBytes(json))) {
			    return (T)serializer.ReadObject(stream);
		    }
	    }
    }
