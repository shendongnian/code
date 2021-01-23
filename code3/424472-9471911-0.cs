    container.Register(
        Component
            .For<IObjectDataContext>()
            .ImplementedBy<ObjectDataContext>()
            .DependsOn(new { connectionString = ConnectionString("EntityFramework") })
    );
