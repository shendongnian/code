	public static class RazorEngineConfigurator
	{
		public static void Configure()
		{
			var templateConfig = new TemplateServiceConfiguration
				{
					Resolver = new DelegateTemplateResolver(name =>
						{
							//no caching cause RazorEngine handles that itself
							var emailsTemplatesFolder = HttpContext.Current.Server.MapPath(Properties.Settings.Default.EmailTemplatesLocation);
							var templatePath = Path.Combine(emailsTemplatesFolder, name);
							using (var reader = new StreamReader(templatePath)) // let it throw if doesn't exist
							{
								return reader.ReadToEnd();
							}
						})
				};
			RazorEngine.Razor.SetTemplateService(new TemplateService(templateConfig));
		}
	}
