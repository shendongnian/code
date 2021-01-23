    container.Register(
        .Component.For<ObjectDataContext>()
        .DependsOn(
            Dependency.OnValue(
                "connectionString", ConnectionString("EntityFramework")))
        .LifeStyle.PerWebRequest);
