    public AppHost()
    	: base("Combined Services", 
    		typeof(ServiceX).Assembly, 
    		typeof(ServiceD).Assembly)
    {
    }
   
