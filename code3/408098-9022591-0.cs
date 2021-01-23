    public static class SomeTypeServiceFactory
    {
    	public static ISomeTypeService GetService()
    	{
    		SomeTypeRepository someTypeRepository = new SomeTypeRepository();
    
    		// Somewhere in here I need to figure out if i'm in testing mode 
    		// and i have to do this in a scope which is not in the setup of my
                // unit tests
    
    		return new SomeTypeService(someTypeRepository);
    	}
    
    	private static ISomeTypeService GetServiceForTesting()
    	{
    		SomeTypeRepository someTypeRepository = new SomeTypeRepository();
    		return new SomeTestingTypeService(someTypeRepository);
    	}
    }
