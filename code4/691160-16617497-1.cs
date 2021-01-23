    public static class Serializer
    {
    	public static string SerializeObject(object objectToSerialize)
    	{
    		XmlSerializer x = new XmlSerializer(objectToSerialize.GetType());
    
    		StringWriter writer = new StringWriter();
    		x.Serialize(writer, objectToSerialize);
    
    		return writer.ToString();
    	}
    
    	public static T DeserializeObject<T>(string serializedObject)
    	{
    		XmlSerializer xs = new XmlSerializer(typeof(T));
    		StringReader reader = new StringReader(serializedObject);
    		return (T)xs.Deserialize(reader);
    	} 
    }
