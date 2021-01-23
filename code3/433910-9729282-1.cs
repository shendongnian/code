    void Main()
    {
    	Container c = new Container();
    	c.Options.Add(new Option() { Id=1, DisplayName="Bob", StoredValue="aaaa"});
    	c.Options.Add(new Option() { Id=2, DisplayName="Dora", StoredValue="bbbb"});
    	c.Options.Add(new Option() { Id=3, DisplayName="Sara", StoredValue="cccc"});
    	
	var t = from x in c.Options.OfType<Option>()
			where x.DisplayName == "Bob"
			select x.StoredValue;
	t.Dump();
    			
    }
    
    class BaseType {
      public Int32 Id { get; set; }
    }
    
    class Option : BaseType {
      public String DisplayName { get; set; }
      public String StoredValue { get; set; }
    }
    
    class Container {
      public List<BaseType> Options;
      
      public Container() { Options = new List<BaseType>(); }
    }
