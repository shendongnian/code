    //Extension methods must be defined in a static class 
    public static class StringExtension
    {
    	// This is the extension method. 
    	// The first parameter takes the "this" modifier
    	// and specifies the type for which the method is defined. 
    	public static T MyCloneExtension<T>(this T t)
    	{
    		// Code in this function was copied from https://stackoverflow.com/questions/78536/deep-cloning-objects-in-c-sharp
    		if (!typeof(T).IsSerializable)
    		{
    			throw new ArgumentException("The type must be serializable.", "source");
    		}
    
    		// Don't serialize a null object, simply return the default for that object
    		if (Object.ReferenceEquals(t, null))
    		{
    			return default(T);
    		}
    
    		IFormatter formatter = new BinaryFormatter();
    		Stream stream = new MemoryStream();
    		using (stream)
    		{
    			formatter.Serialize(stream, t);
    			stream.Seek(0, SeekOrigin.Begin);
    			return (T)formatter.Deserialize(stream);
    		}
    	}
    }
