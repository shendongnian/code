    [Serializable]
    public class MyClass: ISerializable
    {
    	// As you are in control of serialization process now
        // [Serialized] and [NonSerialized] attributes are no longer required
    	private NonSerializableDataType myField;
    
    	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    	{
    		// Create and populate your SomeOtherDataType local variable here, then push it into info variable
    		// Or even better, dont create SomeOtherDataType, just put additional serialization data into info variable, for example:
    		info.AddValue("URL", "http://this.way.com");
    	}
    	
    	protected Person(SerializationInfo info, StreamingContext context)
        {
    		// Dont forget to define constructor for deserialization purpose
    		
    		this.myField = new NonSerializableDataType(loadFromURL: (string)info.GetValue("URL", typeof(string)));
    	}
    }
