    container.Register(
       Classes.FromThisAssembly()
          .Where(Component.IsInTheSameNamespaceAs<IUsersQuery>())
          .WithServiceDefaultInterfaces()
          .LifestyleTransient()
    );
