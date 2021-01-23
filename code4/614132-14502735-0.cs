    private static IFoo getDefaultFoo()
    {
    	IFoo result = null;
    	try
    	{
    		if (Baz.canIDoIt())
    		{
    			result = new Foo();
    		}
    
    		return result;
    	}
    	catch
    	{
    		if (result != null)
    		{
    			result.Dispose();
    		}
    
    		throw;
    	}
    }
