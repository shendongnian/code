    public class Entity
    {
    	public ObjectId Id { get; set; }
    
    	public ObjectId PersistedId 
    	{
    		get { return Id; }
    	}
    }
    
    BsonClassMap.RegisterClassMap<Person>(x =>
    {
        x.AutoMap();
        x.MapMember(x => x.PersistedId);
    });
