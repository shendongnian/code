    TemplateServiceConfiguration templateConfig = new TemplateServiceConfiguration
    {
         Resolver = new TemplateResolver()
    };
    Razor.SetTemplateService(new TemplateService(templateConfig));
