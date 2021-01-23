		internal static ITemplateService InstanceTemplateService()
		{
			TemplateServiceConfiguration configuration = new TemplateServiceConfiguration
			{
				Resolver = new EmbeddedTemplateResolver(typeof(EmailTemplate))
			};
			ITemplateService service = new TemplateService(configuration);
			return service;
		}
