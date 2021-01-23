    [DataContract]
    partial class Trigger
    {
    	public virtual bool isMet()
    	{
    		return false;
    	}
    }
    
    [DataContract]
    class DerivedTrigger : Trigger
    {
    	public override bool isMet()
    	{
    		return true;
    	}
    }
    
    void Main()
    {
    	DerivedTrigger t = new DerivedTrigger();
    	Serialize(t);
    	((Trigger)Deserialize()).isMet(); // returns True!
    }
    
    // These two variables represent storage in a Database
    public static MemoryStream serializedObject = new MemoryStream(); 
    public static Type serializedObjectType;
    
    public static void Serialize<T>(T source)
    {
    	serializedObjectType = typeof(T);
    	DataContractSerializer dcs = new DataContractSerializer(serializedObjectType, null, int.MaxValue, false, true, null);
    	dcs.WriteObject(serializedObject, source);
    }
    
    public static object Deserialize()
    {
    	serializedObject.Position = 0;
    	DataContractSerializer dcs = new DataContractSerializer(serializedObjectType, null, int.MaxValue, false, true, null);
    	return dcs.ReadObject(serializedObject);
    }
