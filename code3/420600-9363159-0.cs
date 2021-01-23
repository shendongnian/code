    [DataContract]
    public class WCFDataClass
    {
    	[DataMember]
    	public String Foo { get; set; }
    }
    
    // Your class, used for internal processing
    class MyWCFDataClass : WCFDataClass
    {
    	private String MyFoo { get; set; }
    	
    	String DoFoo()
    	{
    		return this.Foo + this.MyFoo;
    	}
    }
