    protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings = GetSerializeSettings();
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.UseXmlSerializer = true;
        }
        internal JsonSerializerSettings GetSerializeSettings()
        {
            return new JsonSerializerSettings
                               {
                                   Formatting = Formatting.Indented,
                                   ContractResolver = new CamelCasePropertyNamesContractResolver(),
                                   Converters = new List<JsonConverter> { new IsoDateTimeConverter() }
                               };
        }
