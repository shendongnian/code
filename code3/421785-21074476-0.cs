    private IRepository<User> Repo;
        public override void Initialize(string name, NameValueCollection config)
        {
            // use autoface scope to resole service
            using (var scope = AutofacBootstrapper.Container.BeginLifetimeScope())
            {
                Repo = scope.Resolve<IRepository<User>>();
            }
            if (config == null)
                throw new ArgumentNullException("config");
            // Initialize the abstract base class.
            base.Initialize(name, config);
        }
