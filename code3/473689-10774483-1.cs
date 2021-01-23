    container.Register(
                Component.For<IUserRepo>()
                .LifeStyle.Transient.
                .ImplementedBy<YourRealUserRepo>());
    container.Register(
                Component.For<ValidationRepository>()
                    .LifestyleTransient());
