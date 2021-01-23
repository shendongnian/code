    public static class BootStrapper
    {
        public static void Configure(Container container)
        {
            var lifetimeScope = new LifetimeScopeLifestyle();
            container.Register<IUnitOfWork, UnitOfWork>(lifetimeScope);
            //this query needs improvement
            var registrations =
                from type in typeof(IRepository<>).Assembly.GetExportedTypes()
                where typeof(IRepository).IsAssignableFrom(type)
                    && type.IsClass
                    && !type.IsAbstract
                from service in type.GetInterfaces()
                where service.IsGenericType
                select new { Service = service, Implementation = type };
            foreach (var registration in registrations)
            {
                container.Register(registration.Service, 
                    registration.Implementation, lifetimeScope);
            }
        }
    }
