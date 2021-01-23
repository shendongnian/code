    public static class ObjectContextPerHttpRequest
    {
    	public static TestCasesModelContainer Context
    	{
    		get
    		{
    			string objectContextKey = HttpContext.Current.GetHashCode().ToString("ObjectContextPerHttpRequest");
    		   
    			if (!HttpContext.Current.Items.Contains(objectContextKey))
    			{
    				HttpContext.Current.Items.Add(objectContextKey, new TestCasesModelContainer());
    			}
    
    			return HttpContext.Current.Items[objectContextKey] as TestCasesModelContainer;
    		}
    	}
    }
