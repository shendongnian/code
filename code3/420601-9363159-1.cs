    [DataContract]
    public class WCFDataClass
    {
    	[DataMember]
    	public String Foo { get; set; }
    }
    
    // Your class, used for internal processing
    class MyWCFDataClass : WCFDataClass
    {
    	public String MyFoo { get; set; }
    	
    	public String DoFoo()
    	{
    		return this.Foo + this.MyFoo;
    	}
    }
