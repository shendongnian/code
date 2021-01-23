    public class GroupData {
        [JsonIgnore]
    	public string groupParam { get; set; }
        [JsonIgnore]
    	public GroupData nestedObject { get; set; }
    }
    public class BigData : GroupData {
    	public string[] arrayData { get; set; }
    }
    public class ObjectConverter<T> : CustomCreationConverter<T>
	{
        public ObjectConverter() { }
	    public override bool CanConvert(Type objectType)
	    {
	    	return objectType.Name == "BigData";
	    }
	    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
        	// Some additional checks/work?
           serializer.Populate(reader, target);
        }
    }
