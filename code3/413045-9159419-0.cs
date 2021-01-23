    builder
        .RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
        .Where(t => t.GetInterfaces()
        .Any(i => i.IsAssignableFrom(typeof (IDependency))))
        .AsImplementedInterfaces()
        .InstancePerDependency();
