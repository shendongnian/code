	protected override void OnLoad(EventArgs e)
    {  
		try
		{
			var requestObject = requestMapper.Map(Request.Params);
			stringParam = requestObject.StringParam;
			// so on, so forth. Unpack them to the class variables first.
            // Eventually, just use the request object everywhere, maybe.
		}
		catch(SpecificPageRequestMappingException ex)
		{
			log.ErrorFormat("Error loading page: {0}", ex.Message);
			// display error page
		}
	}
