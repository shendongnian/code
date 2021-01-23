    public static void Configure(Func<IAutoRegistration,IAutoRegistration> configuration)
    {
        // Create new UnityContainer with auto registration
        container = new UnityContainer();
        var autoRegistration = container.ConfigureAutoRegistration();
        // Load assemblies
        var path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin");
        foreach (string dll in Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories))
        {
            autoRegistration.LoadAssemblyFrom(dll);
        }
        // Apply configuration
        configuration(autoRegistration).ApplyAutoRegistration();
    }
