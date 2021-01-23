    public static TService GetService<TService>()
    {
        var repositoryName = String.Concat(typeof(TService).Namespace, Type.Delimiter, typeof(TService).Name.Replace("Service", "Repository"));
        object repository = Activator.CreateInstance(Type.GetType(repositoryName));
        return (TService)Activator.CreateInstance(typeof(TService), repository);
    }
