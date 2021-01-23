     var myRepositories = Assembly.GetAssembly(typeof(Repository<>))
                .GetTypes()
                .Where(x => x.BaseType != null && x.BaseType.GetGenericArguments().FirstOrDefault() != null)
                .ToDictionary(x => x.BaseType.GetGenericArguments().FirstOrDefault(), 
                                x => Activator.CreateInstance(x) as IRepository );
