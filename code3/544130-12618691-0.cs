       public ProductNames
    {
    	public readonly static DEVICE1 = new ProductNames("DEVICE1");
    	public readonly static DEVICE2 = new ProductNames("DEVICE2");
    	public readonly static DEVICE3 = new ProductNames("DEVICE3");
    
    	public string Name{get{return _name;}}	
    	private readonly _name ;
    	
    	private ProductNames(string name)
    	{
    		_name = name;
    	}  
    }
    
    // usage
    ProductNames pn = GetProcuctName(/* your logic */);
    switch(pn.Name)
    {
    	case ProductNames.DEVICE1.Name:
    		// do smth
    	case ProductNames.DEVICE2.Name:
    		// do smth else
    }
