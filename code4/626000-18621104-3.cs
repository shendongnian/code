		protected void Application_Start()
		{
			ControllerBuilder.Current.SetControllerFactory(new ExtendedControllerFactory());
        System.Web.WebPages.DisplayModeProvider.Instance.Modes.Insert(0, new System.Web.WebPages.DefaultDisplayMode("EN")
			{
				ContextCondition = context => Thread.CurrentThread.CurrentCulture.Name.Equals("en-US", StringComparison.CurrentCultureIgnoreCase)
			});
        System.Web.WebPages.DisplayModeProvider.Instance.Modes.Insert(0, new System.Web.WebPages.DefaultDisplayMode("BR")
			{
				ContextCondition = context => Thread.CurrentThread.CurrentCulture.Name.Equals("pt-BR", StringComparison.CurrentCultureIgnoreCase)
			});
