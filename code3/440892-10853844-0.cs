    private void OnEndRequest(object source, EventArgs args)
	{
		var context = (HttpApplication)source;
		var response = context.Response;
		
		if (context.Context.Items.Contains(SuppressAuthenticationKey))
		{
			context.Server.ClearError(); //Clearing server error
			response.TrySkipIisCustomErrors = true;
			response.ClearContent();
			response.StatusCode = 401;
			response.RedirectLocation = null;
		}
	}
