    var types = Assembly.GetExecutingAssembly().GetTypes();
            
            var concreteRepositoryTypes = (from t in types
                                           where !t.IsAbstract && typeof(IGenericRepository).IsAssignableFrom(t)
                                           select t).ToList();
            foreach (var repositoryType in concreteRepositoryTypes)
            {
                //register like _container.RegisterType(typeof(UsersRepository), typeof(UsersRepository), new TransientLifetimeManager(), new InjectionMember[] { });
                _container.RegisterType(repositoryType, new TransientLifetimeManager(), new InjectionMember[] { });
                var interfaceForRepository = repositoryType.GetInterfaces().FirstOrDefault(x => x != typeof(IGenericRepository));
                if(interfaceForRepository != null)
                    _container.RegisterType(interfaceForRepository, repositoryType, new TransientLifetimeManager(), new InjectionMember[] { });
            }
        }
