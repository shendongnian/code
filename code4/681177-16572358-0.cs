		Context.ClientPage.Start(this, "Run", kv);
	}
	private void Run(ClientPipelineArgs args)
	{
		var id = args.Parameters["id"];
		if(!args.IsPostBack)
		{
			string controlUrl = string.Format("{0}&id={1}", UIUtil.GetUri("control:AltDelete"), id);
			SheerResponse.ShowModalDialog(controlUrl,"","","",true);
			args.WaitForPostBack();
		}
		else
		{
			Logger.LogDebug("post back");
		}
		Logger.LogDebug("out of if");
	}
