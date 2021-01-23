            Assembly myDataContextAssembly = typeof(SomeTypeInTheAssembly).Assembly;
            Type dataContextType = myDataContextAssembly.GetType(ProjectName + "DataContext");
            Type concreteRepositoryType = typeof(Generic<>).MakeGenericType(dataContextType);
            Repository repository = (Repository)System.Activator.CreateInstance(concreteRepositoryType);
            return repository;
