    private DbMigrationsConfiguration FindConfiguration()
    {
        var configurationType = FindType<DbMigrationsConfiguration>(
            ConfigurationTypeName,
            types => types
                         .Where(
                             t => t.GetConstructor(Type.EmptyTypes) != null
                                  && !t.IsAbstract
                                  && !t.IsGenericType)
                         .ToList(),
            Error.AssemblyMigrator_NoConfiguration,
            (assembly, types) => Error.AssemblyMigrator_MultipleConfigurations(assembly),
            Error.AssemblyMigrator_NoConfigurationWithName,
            Error.AssemblyMigrator_MultipleConfigurationsWithName);
        return configurationType.CreateInstance<DbMigrationsConfiguration>(
            Strings.CreateInstance_BadMigrationsConfigurationType,
            s => new MigrationsException(s));
    }
