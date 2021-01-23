    fluentConfiguration.Mappings(map => map.AutoMappings.Add(
                AutoMap.AssemblyOf<AbstractBaseClass>()
                    .Where(x => x.IsSubclassOf(typeof(Entity)))
                    .IncludeBase<AbstractBaseClass>()
                    .Polymorphism.Explicit()
                    .Conventions.Add(DefaultCascade.All())));
