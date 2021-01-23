    public ModuleActionCollection ModuleActions
    {
    	get
    	{
    		ModuleActionCollection Actions = new ModuleActionCollection();
       		Actions.Add(ModuleContext.GetNextActionID(),
    					"Bla",
    					"",
    					"",
    					"",
    					"javascript:" + Page.ClientScript.GetPostBackEventReference(this, "ARGUMENT"),
    					Page.ClientScript.GetPostBackEventReference(this, "ARGUMENT"),
    					false,
    					DotNetNuke.Security.SecurityAccessLevel.Edit,
    					true,
    					false);
    		return Actions;
    	}
    }
	public void RaisePostBackEvent(String eventArgument)
	{
		if (eventArgument.ToUpper() == "ARGUMENT")
		{
			...
			Globals.Redirect(HttpContext.Current.Request.RawUrl, false);
		}
	}
