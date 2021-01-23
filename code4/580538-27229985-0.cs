    public HelpController()
            : this(GlobalConfiguration.Configuration)
        {
        }
        public HelpController(HttpConfiguration config)
        {
            Configuration = config;
        }
