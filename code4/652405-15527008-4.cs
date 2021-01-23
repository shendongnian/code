    public Guid IsServerReachableOutsideUsingScope()
    {
    	WhoAmIResponse whoAmI;
    	using(var service = new Service())
    		whoAmI = service.Execute();
    	return whoAmI.UserId;
    }
