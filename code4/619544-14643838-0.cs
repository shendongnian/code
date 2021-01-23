    protected void Application_EndRequest(object sender, EventArgs e)
		{
			BusinessLayerService.Instance.Dispose();
			BusinessLayerService.Instance = null;
		}
