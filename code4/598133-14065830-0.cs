    class SpecificPageRequestMapper 
    {
    	public SpecificPageRequest Map(NameValueCollection parameters)
    	{
    		var request = new SpecificPageRequest();
    		string stringParam = parameters["stringParam"];
    		if (String.IsNullOrEmpty(stringParam))
    		{
    			throw new SpecificPageRequestMappingException("No parameter");
    		}
    		
    		request.StringParam = stringParam;
    		
    		// more parameters
    		
    		...
    		
    		return request;
    	}
    }
    
    class SpecificPageRequest
    {
    	public string StringParam { get; set; }
        // more parameters...
    }
