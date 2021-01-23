    container.Register(Classes.FromAssemblyContaining<Repository>()
                                   .Where(Component.IsInSameNamespaceAs<Repository>())
                                   .WithService
                                   .DefaultInterfaces()
                                   .LifestylePerWebRequest());
