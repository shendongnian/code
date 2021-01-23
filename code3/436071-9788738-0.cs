    public class MyClass
    {
    	public Guid InstanceID {get; set;}
    	// Other properties, etc.
    	
    	public MyClass()
    	{
    		this.InstanceID = Guid.NewGuid();
    	}
    	
    	void PrintUniqueInstanceID() 
    	{   
    		Console.Write("Unique ID for the *instance* of this class: {0}", this.InstanceID); 
    	} 
    }
