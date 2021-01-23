                return Fluently.Configure()
                .Database(DatabaseConfig)
                .Mappings(m => m.AutoMappings.Add(AutoMap.Assembly(typeof(IDependency).Assembly)
                .OverrideAll(p => {
                    p.SkipProperty(typeof(NoEntity)); 
                }).Where(IsEntity)))
                .ExposeConfiguration(ValidateSchema)
                .ExposeConfiguration(BuildSchema)
                .BuildConfiguration();
