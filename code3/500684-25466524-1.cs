	public override void Init()
	{
		base.Init();
		this.AcquireRequestState += showRouteValues;
	}
	protected void showRouteValues(object sender, EventArgs e)
	{
		var context = HttpContext.Current;
		if (context == null)
			return;
		var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(context)); 
    }
