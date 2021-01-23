            protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            // Use LocalDB for Entity Framework by default
            Database.DefaultConnectionFactory = new SqlConnectionFactory(@"Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True");
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            ModelValidatorProviders.Providers.Add(new MyCustomModelValidatorProvider());
        }
