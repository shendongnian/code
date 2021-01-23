    public static void Register(IAppHost appHost)
    {
    	appHost.ContentTypeFilters.Register( "text/x-vcard", SerializeToStream,  DeserializeFromStream);
    }
  
    ...    
    
    public static void SerializeToStream(IRequestContext requestContext, object response, Stream stream)
    {
    	var customerDetailsResponse = response as CustomerDetailsResponse;
    	using (var sw = new StreamWriter(stream))
    	{
    		if (customerDetailsResponse != null)
    		{
    			WriteCustomer(sw, customerDetailsResponse.Customer);
    		}
    		var customers = response as CustomersResponse;
    		if (customers != null)
    		{
    			customers.Customers.ForEach(x => WriteCustomer(sw, x));
    		}
    	}
    }
