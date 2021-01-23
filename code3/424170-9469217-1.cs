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
    
    public static void Serialize<T>(T source)
    {
        MemoryStream ms = new MemoryStream();
    	Type serializedObjectType = typeof(T);
    	DataContractSerializer dcsObject = new DataContractSerializer(serializedObjectType, null, int.MaxValue, false, true, null);
    	dcsObject.WriteObject(ms, source); //serialize the object
        
        byte[] buffer = new byte[1024] //TODO:  adjust size
        ms.Position = 0;
        ms.Read(buffer, 0, 1024);
        //TODO: write buffer to database colObject here
        ms.Position = 0;
        DataContractSerializer dcsType = new DataContractSerializer(typeof(Type), null, int.MaxValue, false, true, null);
        dcsType.WriteObject(ms, serializedObjectType.DeclaringType);
        
        buffer = new byte[1024]
        ms.Position = 0;
        ms.Read(buffer, 0, 1024);
        //TODO: write buffer to database colType here
    }
    
    public static object Deserialize()
    {
        MemoryStream ms = new MemoryStream();
        byte[] buffer = new byte[1024];
        //TODO: read colType into buffer here
        
        ms.Write(buffer, 0 1024);
        ms.Position = 0;
        DataContractSerializer dcsType = new DataContractSerializer(typeof(Type), null, int.MaxValue, false, true, null);
        Type serializedObjectType = dcs.Read(ms);
        //TODO: read colObject into buffer here
    	DataContractSerializer dcs = new DataContractSerializer(serializedObjectType, null, int.MaxValue, false, true, null);
    	return dcs.ReadObject(serializedObject);
    }
