        var assemblies = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "Worker*.dll").Select(f => Assembly.LoadFile(f)).ToArray<Assembly>();
        (from asm in assemblies
            from t in asm.GetExportedTypes()
            where typeof(ICommonWorker).IsAssignableFrom(t) && t.IsClass
            select t).ForEach(x =>
        {
            unityContainer.RegisterType(typeof(ICommonWorker), x, x.FullName, new ContainerControlledLifetimeManager());
        });
