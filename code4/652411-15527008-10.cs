    public Guid IsServerReachableWithinUsingScope()
    {
    	using(var service = new Service())
    	{
    		WhoAmIResponse whoAmI = service.Execute();
    		return whoAmI.UserId;
    	}
    }
