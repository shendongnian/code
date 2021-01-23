        public override void Configure(Container container)
        {
            // .... some config code omitted....
            var appSettings = new AppSettings();
            AppConfig = new AppConfig(appSettings);
            container.Register(AppConfig);
            container.Register<ICacheClient>(new MemoryCacheClient());
            container.Register<ISessionFactory>(c => new SessionFactory(c.Resolve<ICacheClient>()));
            this.Plugins.Add(
                new AuthFeature(
                    // using a custom AuthUserSession here as other checks performed here, e.g. validating Google Apps domain if oAuth enabled/plugged in.
                    () => new CustomAuthSession(), 
                    new IAuthProvider[] { new UmbracoAuthProvider(appSettings) 
                                        }) {
                                              HtmlRedirect = "/api/login" 
                                           });
    }
