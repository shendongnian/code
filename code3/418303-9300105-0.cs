    void Main()
    {
    	var values = new Dictionary<string,object> { 
    		{ "x", 5 }, { "Foo", "Bar" }
    	};
    	
    	dynamic expando = new ExpandoDictionary(values);
    	
    	// We can lookup members in the dictionary by using dot notation on the dynamic expando
    	Console.WriteLine(expando.x);
    	// And assign new "members"
    	expando.y = 42;
    	expando.Bar = DateTime.Now;
    	// The value set is in the dictionary
    	Console.WriteLine(values["Bar"]);
    }
    
    public class ExpandoDictionary : DynamicObject 
    {
    	private readonly Dictionary<string,object> inner;
    	
    	public ExpandoDictionary(Dictionary<string,object> inner)
    	{
    		this.inner = inner;
    	}
    	
    	public override bool TrySetMember(SetMemberBinder binder, object value) 
    	{
    		inner[binder.Name] = value;
    		return true;
    	}
    	
    	public override bool TryGetMember(GetMemberBinder binder, out object value) 
    	{
    		return inner.TryGetValue(binder.Name, out value);
    	}
    }
