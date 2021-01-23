    #Global.asax.cs
	protected void Application_Start()
	{
		AreaRegistration.RegisterAllAreas();
		Database.SetInitializer<Models.MyDb1>(null);
		Database.SetInitializer<Models.MyDb2>(null);
		
		...
	}
