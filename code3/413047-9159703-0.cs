    var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var builder = new ContainerBuilder();
        builder.RegisterAssemblyTypes(assemblies)
            .Where(t => t.BaseType == typeof(PluginBase))
            .As<PluginBase>();
        var container = builder.Build();
        var pluginClasses = container.Resolve<IEnumerable<PluginBase>>();
